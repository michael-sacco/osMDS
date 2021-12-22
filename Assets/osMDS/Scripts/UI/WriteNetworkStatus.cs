using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteNetworkStatus : MonoBehaviour
{
    [SerializeField] InitiateNetworkConnection networkMgr;
    [SerializeField] TextMeshProUGUI text;
    

    void LateUpdate()
    {
        text.text = networkMgr.networkState;
    }
}
