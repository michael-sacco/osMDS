using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using System;

public class GetLeaderboardData : MonoBehaviour
{
    public Action LeaderboardDataLoaded;

    [SerializeField] TrackPlayerData playerData;
    [SerializeField] FadeCanvasGroup fadeComponent;

    // Start is called before the first frame update
    void Start()
    {
        SubmitScore();
    }

    void SubmitScore()
    {
        string memberID = Guid.NewGuid().ToString();
        string leaderboardID = InitiateNetworkConnection.leaderboardID.ToString();
        string metadata = InitiateNetworkConnection.playerName.ToString();
        int score = playerData.TotalScore;

        LootLockerSDKManager.SubmitScore(memberID, score, leaderboardID, metadata, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
                GetScores();
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    void GetScores()
    {
        int count = 10;
        int leaderboardID = InitiateNetworkConnection.leaderboardID;

        LootLockerSDKManager.GetScoreList(leaderboardID, count, (response) =>
        {
            if (response.statusCode == 200)
            {
                leaderboardData = new List<LeaderboardRecord>();
                for (int i = 0; i < response.items.Length; i++)
                {
                    LeaderboardRecord newRecord = new LeaderboardRecord(
                        response.items[i].metadata,
                        response.items[i].score
                        );
                    
                    leaderboardData.Add(newRecord);
                }
                LeaderboardDataLoaded();
                fadeComponent.ExecuteCrossfade();
                Debug.Log("Fetching Scores Successful.");
            }
            else
            {
                Debug.Log("Fetching scores failed: " + response.Error);
            }
        });
    }

    public List<LeaderboardRecord> leaderboardData;

    public class LeaderboardRecord
    {
        public string metadata;
        public int score;

        public LeaderboardRecord(string metadata, int score)
        {
            this.metadata = metadata;
            this.score = score;
        }
    }
}
