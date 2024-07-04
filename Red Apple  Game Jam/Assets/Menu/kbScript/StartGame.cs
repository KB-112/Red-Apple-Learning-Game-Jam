using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public Button startGame;
    public GameObject storyTellingScene;

    private void Start()
    {
        startGame.onClick.AddListener(FadeStart);
       
    }

    void FadeStart()
    {
        startGame.enabled = false;
        StartCoroutine(GameManagerMenu.Instance.fade.FadeInOut(() =>
        {

            storyTellingScene.SetActive(true);
        }));
    }
}
