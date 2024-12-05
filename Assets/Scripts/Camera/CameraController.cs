using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float distance = 5f;
    private float height = 2f;
    private float smoothSpeed = 0.125f;
    private float verticalSmoothTime = 0.2f;

    private Vector3 offset;
    private float currentHeight;
    private float verticalVelocity;

    void Start()
    {
        if (player != null)
        {
            offset = -player.transform.forward * distance + Vector3.up * height;
            currentHeight = player.transform.position.y + height;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.transform.position - player.transform.forward * distance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        float targetHeight = player.transform.position.y + height;
        currentHeight = Mathf.SmoothDamp(currentHeight, targetHeight, ref verticalVelocity, verticalSmoothTime);
        smoothedPosition.y = currentHeight;

        transform.position = smoothedPosition;
        transform.LookAt(player.transform.position + Vector3.up * height / 2);
    }
}