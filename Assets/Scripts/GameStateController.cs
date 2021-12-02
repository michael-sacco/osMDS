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
        Debug.Log("Called On Player Die");
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
