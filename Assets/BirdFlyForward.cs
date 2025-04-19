using UnityEngine;

public class BirdSoundTest : MonoBehaviour
{
    public AudioClip testClip;

    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();

        source.clip = testClip;
        source.loop = true;
        source.playOnAwake = false;
        source.spatialBlend = 0f; // 2D sound
        source.volume = 1f;

        source.Play();
    }
}
