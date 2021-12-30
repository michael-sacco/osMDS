using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ExitUIHandler : MonoBehaviour
{
    [SerializeField] private ApplicationExitHandler exitHandler;
    [SerializeField] private GameObject targetGameObject;

    private void LateUpdate()
    {
        SetUIState();
    }

    void SetUIState()
    {
        switch (exitHandler.exitState)
        {
            case ApplicationExitHandler.ExitState.Playing:
                targetGameObject.SetActive(false);
                break;
            case ApplicationExitHandler.ExitState.OnPrompt:
                targetGameObject.SetActive(true);
                break;
        }
    }
}
