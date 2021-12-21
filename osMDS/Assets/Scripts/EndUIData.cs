using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUIData : MonoBehaviour
{
    [SerializeField]
    PlayerEntity playerEntity;

    [SerializeField]
    GameObject canvas;

    [SerializeField] GameObject helperCanvas;

    private void Awake()
    {
        canvas.SetActive(false);
        helperCanvas.SetActive(false);
    }

    void Start()
    {
        playerEntity.onPlayerDie += OnPlayerDie;
    }

    void OnPlayerDie()
    {
        Debug.Log("OnDie");
        StartCoroutine(CleanExit());
    }

    IEnumerator CleanExit()
    {
        helperCanvas.SetActive(true);
        yield return new WaitForSeconds(1);
        canvas.SetActive(true);
    }

}
