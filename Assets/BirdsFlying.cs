using UnityEngine;

public class BirdFlyForward : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move the bird forward every frame
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}

