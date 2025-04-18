using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Promotion_check : MonoBehaviour
{
    public TextMeshProUGUI timerText;       // Reference to the Timer's TextMeshProUGUI
    public TextMeshProUGUI heartRateText;   // Reference to the Heart Rate's TextMeshProUGUI
    public TextMeshProUGUI resultMessage;   // Result Message to show success/failure
    public GameObject resultPanel;          // Panel to show results
    public Button nextLevelButton;          // Button to proceed to next level

    public int healthyHeartRateMin = 60;    // Healthy min heart rate
    public int healthyHeartRateMax = 100;   // Healthy max heart rate

    private float totalHeartRate = 0f;
    private int sampleCount = 0;
    private bool resultEvaluated = false;

    void Start()
    {
        if (resultPanel != null)
            resultPanel.SetActive(false);

        if (nextLevelButton != null)
            nextLevelButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if timer is running (the timer value will decrease, so we check the text itself)
        if (float.TryParse(timerText.text, out float remainingTime) && remainingTime > 0f)
        {
            // Collect heart rate data while the timer is running
            if (int.TryParse(heartRateText.text, out int currentHR))
            {
                totalHeartRate += currentHR;
                sampleCount++;
            }
        }
        else if (!resultEvaluated) // Timer has stopped
        {
            resultEvaluated = true;
            EvaluateHeartRate();
        }
    }

    void EvaluateHeartRate()
    {
        if (resultPanel != null)
            resultPanel.SetActive(true);

        if (sampleCount == 0)
        {
            resultMessage.text = "No heart rate data collected.";
            return;
        }

        float averageHR = totalHeartRate / sampleCount;
        int roundedHR = Mathf.RoundToInt(averageHR);

        if (averageHR >= healthyHeartRateMin && averageHR <= healthyHeartRateMax)
        {
            resultMessage.text = $"✅ Success! Avg HR: {roundedHR} BPM\nYou can proceed!";
            if (nextLevelButton != null)
                nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            resultMessage.text = $"❌ Try Again! Avg HR: {roundedHR} BPM\nStay in the healthy zone.";
            if (nextLevelButton != null)
                nextLevelButton.gameObject.SetActive(false);
        }
    }

    public void ResetMonitor()
    {
        totalHeartRate = 0f;
        sampleCount = 0;
        resultEvaluated = false;

        if (resultMessage != null) resultMessage.text = "";
        if (resultPanel != null) resultPanel.SetActive(false);
        if (nextLevelButton != null) nextLevelButton.gameObject.SetActive(false);
    }
}
