using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLeaderboardRecord : MonoBehaviour
{
    GetLeaderboardData datasource;

    [SerializeField] TextMeshProUGUI metadata;
    [SerializeField] TextMeshProUGUI score;

    [SerializeField] int recordNo = 0;

    // Start is called before the first frame update
    void Start()
    {
        datasource = FindObjectOfType<GetLeaderboardData>();
        if (datasource == null || metadata == null || score == null)
            return;
        
        datasource.LeaderboardDataLoaded += WriteData;

        metadata.text = "";
        score.text = "";
    }

    void WriteData()
    {
        if (datasource == null || metadata == null || score == null)
            return;

        if (recordNo > datasource.leaderboardData.Count - 1)
            return;

        string metadataText = datasource.leaderboardData[recordNo].metadata;
        string scoreText = datasource.leaderboardData[recordNo].score.ToString("N0");

        metadata.text = metadataText;
        score.text = scoreText;
    }
}
