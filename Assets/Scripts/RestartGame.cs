using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] PlayerEntity playerEntity;
    
    void Update()
    {
        ReloadScene();
    }

    void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerEntity.EntityState == HelperFunctions.EntityState.Dead)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
