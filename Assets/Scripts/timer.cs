using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI timerText;     // Assign in Inspector
    public float startTimeInSeconds = 10f; // Countdown start time
    public bool isRunning = true;

    private float remainingTime;

    void Start()
    {
        remainingTime = startTimeInSeconds;
        timerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }

    void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;

            float displayTime = Mathf.Max(remainingTime, 0f);
            timerText.text = Mathf.CeilToInt(displayTime).ToString();

            if (remainingTime <= 0f)
            {
                isRunning = false;
                OnTimerStopped();
            }
        }
    }

    private void OnTimerStopped()
    {
        Debug.Log("Countdown finished!");
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        remainingTime = startTimeInSeconds;
        timerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }

    // Optionally expose remaining time
    public float GetRemainingTime() => Mathf.Max(remainingTime, 0f);
}
