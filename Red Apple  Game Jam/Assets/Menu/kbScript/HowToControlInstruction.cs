
using UnityEngine;
using UnityEngine.UI;



public class HowToControlInstruction : MonoBehaviour
{

    
    private void Start()
    {
        Initialization();
        GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[0].onClick.AddListener(delegate { TextPanel( GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[0]); });
        GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[1].onClick.AddListener(delegate { TextPanel( GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[1]); });
    }

    void Initialization()
    {
        Panel(0);
    }
    void MoveForward()
    {
        if (GameManagerMenu.Instance.controlInstruction.pageIndex < GameManagerMenu.Instance.controlPanel.Count-1)
        {
            GameManagerMenu.Instance.controlInstruction.pageIndex++;
        }
    }
    void MoveBackward()
    {
        if ( GameManagerMenu.Instance.controlInstruction.pageIndex > 0)
        {
         
             GameManagerMenu.Instance.controlInstruction.pageIndex--;
        }
    }

    void TextPanel(Button btn)
    {
        
            if (btn ==  GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[0])
            {
                Debug.Log("Right Btn");
                MoveForward();
            }
            if (btn ==  GameManagerMenu.Instance.controlInstruction.leftAndRightBtn[1])
            {
                Debug.Log("Left Btn");
                MoveBackward();
            }
            Panel( GameManagerMenu.Instance.controlInstruction.pageIndex);
        
    }

    void Panel(int index)
    {
        Debug.Log("Current index: " + GameManagerMenu.Instance.controlInstruction.pageIndex);

        for (int j = 0; j < GameManagerMenu.Instance.controlPanel.Count; j++)
        {
            foreach (var control in GameManagerMenu.Instance.controlPanel[j].Control)
            {
                control.SetActive(j == index);
            }
            Debug.Log((j == index) ? "Active index: " + j : "Non-Active index: " + j);
        }
        if (!GameManagerMenu.Instance.controlPanel[1].Control[0].activeSelf)
        {
            GameManagerMenu.Instance.controlPanel[1].Control[0].SetActive(GameManagerMenu.Instance.controlInstruction.pageIndex > 1);
        }

    } 
    

}
