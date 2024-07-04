using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
   
    private bool isMute = false;
    public Image soundImages;
    public Sprite[] muteSprite;
    public Button audioBtn;

    void Start()
    {
        AssignClip();
        if (GameManagerMenu.Instance.musicSystem.backgroundAudioSource == null)
        {
            GameManagerMenu.Instance.musicSystem.backgroundAudioSource = GetComponent<AudioSource>();
        }

       
        audioBtn.onClick.AddListener(ToggleMute);


        UpdateMuteButtonImage();
    }

    
   
   

    // Method to toggle mute state
    public void ToggleMute()
    {
        isMute = !isMute;
        UpdateMuteButtonImage();

        if (isMute)
        {
            GameManagerMenu.Instance.musicSystem.backgroundAudioSource.volume =0;
        }
        else
        {
            GameManagerMenu.Instance.musicSystem.backgroundAudioSource.volume = 1f;
        }
    }

   
    private void UpdateMuteButtonImage()
    {
        if (isMute)
        {
            soundImages.sprite = muteSprite[0]; 
        }
        else
        {
            soundImages.sprite = muteSprite[1];
        }
    }


    void AssignClip()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            GameManagerMenu.Instance.musicSystem.backgroundAudioSource.clip = GameManagerMenu.Instance.musicSystem.audioClips[0];
        }
        else if(SceneManager.GetActiveScene().name == "MainGameplay")
        {
            GameManagerMenu.Instance.musicSystem.backgroundAudioSource.clip = GameManagerMenu.Instance.musicSystem.audioClips[2];
        }
    }
}
