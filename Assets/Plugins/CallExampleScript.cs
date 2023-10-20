using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FarlySDK;

public class CallExampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CallingExample - started");
        //TODO: replace with your own apiKey and publisherId
        Farly.Configure("apiKey", "publisherId");

        Farly.getHostedOfferwallUrl(new OfferWallRequest { userId = "your_userId" }, (url) =>
        {
            // inject this into a webview ? Or open it in the browser ?
            Debug.Log($"If you want to display the wall in your own webview, use this url: {url}");
        });
    }

    // Update is called once per frame
    void Update() { }

    public void showOfferwallInBrowser()
    {
        var offerwallRequest = new OfferWallRequest
        {
            userId = "your_userId",
            userGender = "m",
            userAge = 25,
            zipCode = "75017",
            countryCode = "FR",
            userSignupDateTime = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            callbackParameters = new string[] { "cb1", "cb2" },
        };
        Farly.showOfferwallInBrowser(offerwallRequest);
    }

    public void showOfferwallInWebview()
    {
        Farly.showOfferwallInWebview(new OfferWallRequest { userId = "your_userId" });
    }

    public void listOffers()
    {
        Farly.getOfferwall(new OfferWallRequest { userId = "your_userId" }, (offers) =>
            {
                // display them in your own UI ?
                Debug.Log($"We have {offers.Length} offers to display");
            });
    }
}
