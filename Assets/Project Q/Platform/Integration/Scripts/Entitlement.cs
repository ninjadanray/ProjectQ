namespace ProjectQ.Platform.Integration {
    using UnityEngine;
    using Oculus.Platform;

    public class Entitlement : MonoBehaviour
    {
        void Awake()
        {
            try
            {
                Core.AsyncInitialize();
                Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCallBack);
            }
            catch(UnityException e)
            {
                Debug.LogError("Platform failed to initialize due to exception.");
                Debug.LogException(e);

                // Quit the application immediately.
                Quit();
            }
        }

        // Called when the platform completes async entitlement check request and a result is available.
        void EntitlementCallBack(Message msg)
        {
            if (msg.IsError) // User failed entitlement check?
            {
                // Implements a default behaviour for an entitlement check failure,
                // log the failure and exit the app.
                Debug.LogError("You're not entitled to use the app.");
                Quit();
            }
            else // User passed entitlement check?
            {
                // Log the succeed entitlement check for debugging.
                Debug.Log("You're entitled to use the app");
            }
        }

        void Quit() {
            UnityEngine.Application.Quit();
        }
    }
}
