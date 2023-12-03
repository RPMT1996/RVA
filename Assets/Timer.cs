using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    public Text timerText;
    private float timeElapsed = 0f;

    void Start()
    {
        // Get the Text component if not set in the Inspector
        if (timerText == null)
        {
            timerText = GetComponentInChildren<Text>();
        }

        // Set the initial time display
        UpdateTimerDisplay();
    }

    void Update()
    {
        // Update the elapsed time
        timeElapsed += Time.deltaTime;

        // Update the timer display
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // Update the Text element with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
