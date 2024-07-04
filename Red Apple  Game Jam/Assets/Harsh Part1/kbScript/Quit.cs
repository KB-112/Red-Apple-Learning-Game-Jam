using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
   

    private void Start()
    {
     
        QuitApp();
    }

    void QuitApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            Application.Quit();
        }
    }
   
}
