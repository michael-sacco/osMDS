using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] PlayerEntity playerEntity;
    
    void Update()
    {
        DoReload();
    }

    void DoReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerEntity.EntityState == HelperFunctions.EntityState.Dead)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}