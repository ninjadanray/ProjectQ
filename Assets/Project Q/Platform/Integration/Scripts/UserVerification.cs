using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine.Networking;
using TMPro;

namespace ProjectQ.Platform.Integration {
    public class UserVerification : MonoBehaviour
    {
        public UserCredentials userCredentials;

        [SerializeField] private string userId, userName, userPresence, userNonce, userVerified;

        private bool verificationSucceeded = false; // Flag to track verification status

        private WWWForm form;
        
        void Start()
        {
            Entitlement entitlement = GetComponent<Entitlement>();

            // Checking if the user has passed the entitlement
            if (!entitlement.HasEntitlementSucceeded()) return;

            GetLoggedInUser();

            form = new WWWForm();
        }

        private void GetLoggedInUser()
        {
            Users.GetLoggedInUser().OnComplete(OnLoggedInUserCallBack);
        }

        private void OnLoggedInUserCallBack(Message<User> msg) {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error getting logged in user. Error Message: {0}", msg.GetError().Message);
            }
            else
            {
                userCredentials.id = msg.Data.ID.ToString(); // Display this to UI as well.
                userCredentials.username = msg.Data.DisplayName;
                userCredentials.presence = msg.Data.PresenceStatus.ToString();

                // Call this method to get the nonce.
                GetUserProof();
            }
        }

        private void GetUserProof()
        {
            Users.GetUserProof().OnComplete(GetUserProofCallBack);
        }

        private void GetUserProofCallBack(Message<UserProof> msg)
        {
            if (msg.IsError)
            {
                Debug.LogErrorFormat("Oculus: Error getting logged in user. Error Message: {0}", msg.GetError().Message);
            }
            else
            {
                userCredentials.nonce = msg.Data.Value;
                StartCoroutine(ValidateNonce(userId, userCredentials.nonce));
            }
        }

        // Validate the nonce using this https://graph.oculus.com/user_nonce_validate and following the CURL POST,
        // curl -d "access_token=OC|$APP_ID|$APP_SECRET"" -d "nonce=$NONCE" -d "user_id=$USER_ID" https://graph.oculus.com/user_nonce_validate

        IEnumerator ValidateNonce(string id, string nonce)
        {
            yield return new WaitForSeconds(2.0f);

            form.AddField("access_token", userCredentials.accessToken);
            form.AddField("nonce", userCredentials.nonce);
            form.AddField("user_id", userCredentials.id);

            using (UnityWebRequest www = UnityWebRequest.Post(userCredentials.verificationApi, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    // console(www.error)
                }
                else
                {
                    userVerified = www.downloadHandler.text;

                    verificationSucceeded = true; // Set the flag to true
                }
            }
        }

        public bool HasVerificationSucceeded() {
            return verificationSucceeded;
        }

        private void console(string msg) {
            Debug.Log(msg);
        }

    }

}