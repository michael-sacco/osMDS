using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStartHandler : MonoBehaviour
{
    [SerializeField] private GameObject startUICanvas;
    [SerializeField] private NameEntry nameEntry;
    [SerializeField] private GameObject gameplayContainer;
    [SerializeField] private GameObject gameplayUI;

    private void OnEnable()
    {
        nameEntry.onNameSubmit += OnNameSubmit;
    }
    private void OnDisable()
    {
        nameEntry.onNameSubmit -= OnNameSubmit;
    }

    void OnNameSubmit(string name)
    {
        SaveSystem.SavePlayerName(name);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        startUICanvas.GetComponent<FadeCanvasGroup>().ExecuteCrossfade(0f, 1f);
        yield return new WaitForSeconds(1);
        startUICanvas.SetActive(false);
        gameplayContainer.SetActive(true);
        gameplayUI.SetActive(true);
    }
}
