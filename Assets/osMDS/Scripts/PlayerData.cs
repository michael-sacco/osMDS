using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;

    public PlayerData()
    {
        name = InitiateNetworkConnection.playerName;
    }
}
