using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStartHandler : MonoBehaviour
{
    [SerializeField] private GameObject startUICanvas;
    [SerializeField] private NameEntry nameEntry;
    [SerializeField] private GameObject gameplayContainer;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject environment;

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
        float crossFadeDuration = 1f;
        startUICanvas.GetComponent<FadeCanvasGroup>().ExecuteCrossfade(0f, crossFadeDuration);
        yield return new WaitForSeconds(crossFadeDuration);
        startUICanvas.SetActive(false);
        gameplayContainer.SetActive(true);
        gameplayUI.SetActive(true);
        environment.SetActive(true);
    }

    IEnumerator Sample()
    {
        while (true)
        {
            //Dosomething
            yield return null;
        }
    }
}
