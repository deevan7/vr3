using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip clickSound;

    public void PlayClickSound()
    {
        sfxSource.PlayOneShot(clickSound);
    }
}
