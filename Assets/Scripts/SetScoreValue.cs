using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScoreValue : MonoBehaviour
{
    [SerializeField] TrackPlayerData data;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = data.TotalScore.ToString("N0");
    }
}
