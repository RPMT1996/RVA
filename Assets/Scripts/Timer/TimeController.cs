using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    private float timeElapsed = 0f;
    private bool isTimerRunning = false;

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
        if (isTimerRunning)
        {
            // Update the elapsed time
            timeElapsed += Time.deltaTime;

            // Update the timer display
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // Update the Text element with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this function to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Get the current timer value
    public float GetTimer()
    {
        return timeElapsed;
    }

    // Get the formatted timer string (e.g., "05:30")
    public string GetTimerString()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public bool IsTimerRunning()
    {
        return isTimerRunning;
    }
}
