using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    private void Start()
    {
        StartGame(true);
        
        GameManager.Instance.menuComponent.buttons[0].onClick.AddListener(delegate { StartGame(false); });
        GameManager.Instance.menuComponent.buttons[1].onClick.AddListener(OnApplicationQuit);
    }

    void StartGame(bool state)
    {
     
        var inst = GameManager.Instance.menuComponent;
        for (var i = 0; i < inst.menuandGameOver.Length-1; i++)
        {
            inst.menuandGameOver[i].SetActive(state);
        }
        for (var i = 0; i < inst.buttonsObj.Length; i++)
        {
            inst.buttonsObj[i].SetActive(state);
        }
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }

    
}
