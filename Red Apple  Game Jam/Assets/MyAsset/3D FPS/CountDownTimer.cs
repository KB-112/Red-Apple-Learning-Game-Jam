using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float totalTime = 120f; 
    private float remainingTime;
    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        remainingTime = totalTime;
        UpdateTimerDisplay();
        GameManager.Instance.menuComponent.buttons[0].onClick.AddListener(delegate {

            StartCoroutine(StartCountdown());
        });
       
    }

    private IEnumerator StartCountdown()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay();
            yield return null;
        }
        remainingTime = 0;
        UpdateTimerDisplay();
        
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
