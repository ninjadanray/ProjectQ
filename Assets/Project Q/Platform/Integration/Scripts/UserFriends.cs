using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;

namespace ProjectQ.Platform.Integration
{

    public class UserFriends : MonoBehaviour
    {
        // <Summary>
        // If the user is fully verified, You can now start calling UserFriends,
        // to show on its leaderboard, achievements, etc.
        // </Summary>

        [SerializeField] private List<string> userLists = new List<string>();

        void Start() {
            UserVerification userVerification = GetComponent<UserVerification>();

            if (!userVerification.HasVerificationSucceeded()) return;

            GetFriends();
        }

        private void GetFriends() {
            Users.GetLoggedInUserFriends().OnComplete(OnGetUserFriendsCallback);
        }

        private void OnGetUserFriendsCallback(Message<UserList> msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error getting logged in user friends: {0}", msg.GetError().Message);
            }
            else
            {
                PopulateUserFriends(msg);
            }
        }

        private void PopulateUserFriends(Message<UserList> msg) {
            UserList users = msg.GetUserList();

            foreach (User user in users) {
                userLists.Add("Display Name: " + user.DisplayName + "\n" + "Status: " + user.Presence + "\n \n");
            }
        }

    }

}