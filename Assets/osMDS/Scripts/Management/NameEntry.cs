using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[RequireComponent(typeof(TextMeshProUGUI))]
public class NameEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameInput;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    private float audioSourceVolume;
    public Action<string> onNameSubmit;
    private bool isPostSubmit = false;

    private void Start()
    {
        audioSourceVolume = audioSource.volume;
        PlayerData playerData = SaveSystem.LoadPlayer();
        if(playerData != null)
        {
            nameInput.text = playerData.name;
        }
    }

    void Update()
    {
        if (isPostSubmit)
            return;

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
                PlayClickAudio();
            }
        }
        else if ((c == '\n') || (c == '\r')) // enter/return
        {
            if(nameInput.text.Length != 0)
            {
                PlayClickAudio();
                SetUIColor();
                isPostSubmit = true;
                onNameSubmit(nameInput.text);
            }
        }
        else
        {
            if(nameInput.text.Length < 5)
            {
                PlayClickAudio();
                nameInput.text += c;
            }
        }
    }

    void SetUIColor()
    {
        nameInput.color = new Color(0f, 1.0f, 1.0f);
    }


    private void PlayClickAudio()
    {
        audioSource.PlayOneShot(audioClip, UnityEngine.Random.Range(0.8f * audioSourceVolume, audioSourceVolume));
    }
}
