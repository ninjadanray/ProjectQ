using System;

namespace ProjectQ.Platform.Integration {
    [System.Serializable]
    public class UserCredentials
    {
        public string id, username, presence, nonce, verified;

        public string accessToken = "OC|6856195184390701|d67fc81d71aefbd96dd8ce1c369ef11a";

        public string verificationApi = "https://graph.oculus.com/user_nonce_validate";
        public string verify_entitlement_api = "https://graph.oculus.com/6856195184390701/verify_entitlement";

        public string[] skus;
    }
}