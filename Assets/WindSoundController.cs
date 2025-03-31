using UnityEngine;

public class WindAudioController : MonoBehaviour
{
    private AudioSource windAudioSource;

    void Start()
    {
        // Get the AudioSource component
        windAudioSource = GetComponent<AudioSource>();

        // Play the audio (no player movement tracking, just play continuously)
        if (windAudioSource != null && !windAudioSource.isPlaying)
        {
            windAudioSource.Play();
        }
    }
}
