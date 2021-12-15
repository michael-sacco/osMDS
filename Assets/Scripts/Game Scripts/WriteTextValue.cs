using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WriteTextValue : MonoBehaviour
{
    [SerializeField] TrackPlayerData data;
    TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        if (text == null || data == null)
            return;

        string velocity = data.Velocity.ToString();
        string playerInput = data.PlayerInput.ToString();
        string position = data.Position.ToString();
        string currentHp = data.CurrentHP.ToString("N0");
        TimeSpan ts = TimeSpan.FromSeconds(data.AliveTime);
        string aliveTime = ts.ToString("m\\:ss");
        string asteroidsKilled = data.AsteroidsKilled.ToString("N0");
        string totalScore = data.TotalScore.ToString("N0");

        text.SetText("HP: " + currentHp + "\nAlive Time: " + aliveTime + "\nAsteroids Killed: " + asteroidsKilled + "\nScore: " + totalScore);
    }
}
