using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("Scene")]
    private Button button;
    public string SceneName;
    [Header("Addition Screen")]
    public bool EnterAddtionalScreen;
    public GameObject EnterAdditionalScreen_GameObject;
    public bool ExitAdditonalScreen;
    public GameObject ExitAdditionalScreen_GameObject;
    private Animator animator;
 //   private AudioManager backgroundAudioSource;
    public bool hasBGM = false;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        animator = GameObject.Find("FadeScreen").GetComponent<Animator>();
       // backgroundAudioSource = GameObject.Find("ScriptManager").GetComponent<AudioManager>();
    }

    void OnButtonClick()
    {
        if(hasBGM){
           // backgroundAudioSource.ChangeBackgroundAudio(2);
        }
        
        if(EnterAddtionalScreen && ExitAdditonalScreen){
            //backgroundAudioSource.PauseBackgroundAudio();
            Invoke("EnterAdditionScreen",2f);
            Invoke("ExitAdditionalScreen",2f);

        }
        if(EnterAddtionalScreen){
           // backgroundAudioSource.PauseBackgroundAudio();
            Invoke("EnterAdditionScreen",2f);
        }
        else if(ExitAdditonalScreen){
          //  backgroundAudioSource.PauseBackgroundAudio();
            Invoke("ExitAdditionalScreen",2f);
        }
        else if(string.IsNullOrEmpty(SceneName)){
            QuitApplication();
        }
        else{
           // backgroundAudioSource.PauseBackgroundAudio();
            Invoke("DelyInLoadScreen",2f);
        }
        animator.SetTrigger("fade");
    }
    void QuitApplication(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    private void EnterAdditionScreen(){
      //  backgroundAudioSource.ResumeBackgroundAudio();  
        EnterAdditionalScreen_GameObject.SetActive(true);
    }
    private void ExitAdditionalScreen(){
       // backgroundAudioSource.ResumeBackgroundAudio();
        ExitAdditionalScreen_GameObject.SetActive(false);
    }
    private void DelyInLoadScreen(){
        //backgroundAudioSource.ChangeBackgroundAudio(1);
        SceneLoader.Instance.LoadScene(SceneName);
    }
}
