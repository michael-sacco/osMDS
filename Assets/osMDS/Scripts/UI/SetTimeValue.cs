using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SetTimeValue : MonoBehaviour
{
    [SerializeField] TrackPlayerData data;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan ts = TimeSpan.FromSeconds(data.AliveTime);
        text.text = ts.ToString("m\\:ss");
    }
}
