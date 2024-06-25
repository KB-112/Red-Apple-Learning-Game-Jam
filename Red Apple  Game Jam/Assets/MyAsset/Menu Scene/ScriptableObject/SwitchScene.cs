using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : ScriptableObject
{
    public SceneMangement sceneMangement;
   
}

public class SceneMangement
{


    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadMainGameplayScene()
    {
        SceneManager.LoadScene("MainGamePlay");
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

}

