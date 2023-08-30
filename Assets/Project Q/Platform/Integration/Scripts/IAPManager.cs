using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine.UI;
using TMPro;

namespace ProjectQ.Platform.Integration
{
    public class IAPManager : MonoBehaviour
    {
        // <Summary>
        // This script is responsible for managing the IAP Integration from
        // making a purchase, getting all available and purchased SKUs.
        // </Summary>

        // public UserCredentials userCredentials;

        [SerializeField] private TMP_Text availableItems, purchasedItems, notice;

        private WWWForm form;

        // Create new skus in the dashboard.oculus.com with the name following.
        private string[] skus = { "item01", "item02", "item03" };

        void Awake()
        {
            form = new WWWForm();
            userCredentials = GetComponent<UserCredentials>();
        }

        void Start()
        {
            UserVerification userVerification = GetComponent<UserVerification>();

            if (!userVerification.HasVerificationSucceeded()) return;

            // Call get all products and purchased methods
            GetProductList();
            LoadPurchasedProducts();
        }

        public void Buy()
        {
            StartCoroutine(VerifyEntitlementOnProduct());
        }

        private void GetProductList()
        {
            IAP.GetProductsBySKU(skus).OnComplete(ProductListCallBack);

        }

        private void LoadPurchasedProducts()
        {
            IAP.GetViewerPurchases().OnComplete(PurchasedProductsCallBack);
        }

        void ProductListCallBack(Message<ProductList> msg)
        {
            if (msg.IsError) return;

            foreach (var product in msg.GetProductList())
            {
                availableItems.text += $"{product.Name} & {product.FormattedPrice} \n";
            }
        }

        void PurchasedProductsCallBack(Message<PurchaseList> msg)
        {
            if (msg.IsError) return;

            foreach (Purchase purchase in msg.GetPurchaseList())
            {
                purchasedItems.text += $"{purchase.Sku} & {purchase.GrantTime} \n";
            }
        }

        void BuyCallBack(Message<Purchase> msg)
        {
            if (msg.IsError) return;

            purchasedItems.text = string.Empty;

            LoadPurchasedProducts();
        }

        IEnumerator VerifyEntitlementOnProduct()
        {
            yield return new WaitForSeconds(2.0f);

            form.AddField("access_token", userCredentials.accessToken);
            form.AddField("user_id", userCredentials.id);
            form.AddField("sku", "item03");

            using (UnityWebRequest www = UnityWebRequest.Post(userCredentials.verify_entitlement_api, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    notice.text = www.error;
                }
                else
                {
                    string apiResponse = www.downloadHandler.text;
                    ApiResponseData responseData = JsonUtility.FromJson<ApiResponseData>(apiResponse);

                    if (!responseData.success)
                    {
                        notice.text = "Proceeding to checkout!";
                        IAP.LaunchCheckoutFlow(skus[2]).OnComplete(BuyCallBack);
                        yield break;
                    }

                    notice.text = "You already have this item.";
                }
            }
        }
    }

    [System.Serializable]
    public class ApiResponseData
    {
        public bool success;
    }
}