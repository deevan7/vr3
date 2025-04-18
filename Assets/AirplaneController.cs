using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;

    public AudioClip engineLoopClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = engineLoopClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Basic controls
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrows

        // Rotate the plane
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);   // Yaw
        transform.Rotate(Vector3.right, -vertical * rotationSpeed * Time.deltaTime); // Pitch
    }
}
