using UnityEngine;
using TMPro; // Add this namespace

public class DummyMetrics : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text bpsText; // Only keep reference for BPS text

    private float bps; // Beats per second (BPS) or BPM
    private float timer;
    private float updateInterval = 1f; // Update every 1 second

    void Start()
    {
        // Initialize values
        bps = 70f; // Starting at 70 as in your example
        UpdateUI(); // Set initial UI text
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            UpdateMetrics();
            timer = 0f;
        }
    }

    void UpdateMetrics()
    {
        // Update BPS (fluctuate around 70, clamp to 60-100)
        bps += Random.Range(-3f, 8f);
        bps = Mathf.Clamp(bps, 60f, 100f);

        UpdateUI();
    }

    void UpdateUI()
    {
        bpsText.text = $"{Mathf.RoundToInt(bps)}"; // Update only the BPS text
    }
}
