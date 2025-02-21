using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeisRunning = true;
    public TMP_Text timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeisRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeisRunning)
        {
            if (timeRemaining >= 0){
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }
void DisplayTime(float timetoDisplay)
    {
        timetoDisplay += 1; 

        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
