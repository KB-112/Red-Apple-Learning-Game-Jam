using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using System.Collections;
public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float typeSpeed = 0.05f;
    public TextMeshProUGUI ButtonSkip;
    public Button skipButton; 

    private string fullText;
    private string currentText = "";

    void Start()
    {
        fullText = textMeshPro.text;
        StartCoroutine(ShowText());
        skipButton.onClick.AddListener(SkipText); 
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
           
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typeSpeed);
        }
        ButtonSkip.text = "Continue";
    }

   

    public void SkipText()
    {
        StopAllCoroutines();
        textMeshPro.text = fullText; 
        ButtonSkip.text = "Continue";
    }
}
