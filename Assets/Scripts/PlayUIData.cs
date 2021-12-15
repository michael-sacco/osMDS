using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIData : MonoBehaviour
{
    [SerializeField]
    PlayerEntity playerEntity;

    [SerializeField]
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        playerEntity.onPlayerDie += OnPlayerDie;
    }

    void OnPlayerDie()
    {
        canvas.SetActive(false);
    }
}
