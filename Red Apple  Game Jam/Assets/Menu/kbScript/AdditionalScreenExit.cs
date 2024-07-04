
using UnityEngine;
using UnityEngine.UI;
public class AdditionalScreenExit : MonoBehaviour
{

    void Start()
    {
      
            GameManagerMenu.Instance.controlInstruction.exitBtnAditionalScreen.onClick.AddListener(delegate { Screen(false); });
            GameManagerMenu.Instance.controlInstruction.howToPlayBtn.onClick.AddListener(delegate {  Screen(true); });
        
           
        
    }

    void Screen(bool state)
    {
        for (int i = 0; i < GameManagerMenu.Instance.controlInstruction.exitAdditionalScreen.Length; i++)
        {
            GameManagerMenu.Instance.controlInstruction.exitAdditionalScreen[i].SetActive(state);
        }
    }

   
   
}
