using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GameManagerMenu : MonoBehaviour
{  
    public static GameManagerMenu Instance { get; private set; }
    [Header("Menu Controller")]
    public MenuComponents menuComponent;

    [Header("HOW TO PLAY ?")]
    public List<ControlPanel> controlPanel;
    public ControlInstruction controlInstruction;

    public Fade fade;

   

    [Header("MUSIC SYSTEM")]

    public MusicSystem musicSystem;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
}
[System.Serializable]
public class MenuComponents
{
   
    public ParticleSystem particleSystemLeaf;
  
    
    
}

[System.Serializable]
public class ControlPanel
{
    public List<GameObject> Control;

}
[System.Serializable]

public class ControlInstruction
{
    public GameObject additionalscreen;
    public Button[] leftAndRightBtn;
   [HideInInspector]public int pageIndex = 0;
    public Button exitBtnAditionalScreen;
  
    public Button howToPlayBtn;
    public GameObject[] exitAdditionalScreen = new GameObject[2];


}
[System.Serializable]
public class MusicSystem
{
    public AudioSource backgroundAudioSource;
    public AudioClip[] audioClips;

}


[System.Serializable]
public class Fade
{
    public Image backgroundImage;
    public float fadeDuration;

    [HideInInspector] public bool fadeMid = false;

    public IEnumerator FadeInOut(Action onFadeMidReached = null)
    {
        yield return FadeImage(0, 1);

        yield return new WaitForSeconds(1);
        fadeMid = true;

        if (onFadeMidReached != null)
            onFadeMidReached.Invoke();

        yield return FadeImage(1, 0);
    }

    IEnumerator FadeImage(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0;
        Color initialColor = backgroundImage.color;

        while (elapsedTime < fadeDuration)
        {
            float alphaValue = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            backgroundImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, alphaValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        backgroundImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha);
    }



}



