using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    PlayerEntity playerEntity;

    // Start is called before the first frame update
    void Start()
    {
        playerEntity.onPlayerDie += OnPlayerDie;
    }

    void OnPlayerDie()
    {
        DebugLogPlayerDeath();
    }

    void DebugLogPlayerDeath()
    {
        Debug.Log("Called On Player Die");
    }
}
