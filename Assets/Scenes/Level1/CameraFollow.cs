using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public Vector3 offset;          // Offset from the player to position the camera
    public float followSpeed = 5f;   // Speed at which the camera follows the player

    private void LateUpdate()
    {
        if (player != null)
        {
            // Smoothly move the camera towards the player's position + offset
            Vector3 desiredPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Optionally, make the camera look at the player
            transform.LookAt(player);
        }
    }
}
