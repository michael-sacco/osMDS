using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class InitiateNetworkConnection : MonoBehaviour
{
    public static int leaderboardID = 1052;
    public static string playerName = "";
    public string networkState = "";


    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            networkState = "Connecting to Leaderboard network...";

            if (!response.success)
            {
                networkState = "Error connecting to Leaderboard network.";
                Debug.Log("error starting LootLocker session");

                return;
            }

            networkState = "Successfully connected.";
        });
    }
}