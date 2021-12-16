using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NameEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameInput;
    [SerializeField] GameObject gameplayContainer;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject startUICanvas;



    void Update()
    {
        foreach (char c in Input.inputString)
            CharacterHandling(c);
    }


    void CharacterHandling(char c)
    {
        if (c == '\b') // has backspace/delete been pressed?
        {
            if (nameInput.text.Length != 0)
            {
                nameInput.text = nameInput.text.Substring(0, nameInput.text.Length - 1);
            }
        }
        else if ((c == '\n') || (c == '\r')) // enter/return
        {
            if(nameInput.text.Length != 0)
            {
                Debug.Log("on name submit");
                OnNameSubmit();
            }
        }
        else
        {
            if(nameInput.text.Length < 5)
            {
                nameInput.text += c;
            }
        }
    }

    void OnNameSubmit()
    {
        InitiateNetworkConnection.playerName = nameInput.text;
        nameInput.color = new Color(0f, 1.0f, 1.0f);
        StartCoroutine(StartGame());
    }


    IEnumerator StartGame()
    {
        startUICanvas.GetComponent<FadeCanvasGroup>().ExecuteCrossfade(0f, 1f);
        yield return new WaitForSeconds(1);
        gameplayContainer.SetActive(true);
        gameplayUI.SetActive(true);
    }

}
