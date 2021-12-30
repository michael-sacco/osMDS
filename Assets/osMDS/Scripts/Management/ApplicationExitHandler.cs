using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ApplicationExitHandler : MonoBehaviour
{
    public Action<KeyCode> keyPress;
    public ExitState exitState = ExitState.Playing;

    private void Update()
    {
        switch (exitState)
        {
            case ExitState.Playing:
                CheckForKeysPlaying();
                break;
            case ExitState.OnPrompt:
                CheckForKeysOnPrompt();
                break;
        }

        if (exitState == ExitState.RequestedExit)
        {
            Application.Quit();
        }
            
    }

    void CheckForKeysPlaying()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitState = ExitState.OnPrompt;
        }
    }

    void CheckForKeysOnPrompt()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitState = ExitState.RequestedExit;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            exitState = ExitState.Playing;
        }
    }

    public enum ExitState
    {
        Playing,
        OnPrompt,
        RequestedExit
    }
}
