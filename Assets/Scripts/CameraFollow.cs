using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float smoothing = 5f;  // Smoothing factor for camera movement
    public GameObject sala;  // Reference to the Sala object

    private Renderer salaRenderer;  // Renderer of the Sala object
    private Camera mainCamera;  // Reference to the camera
    private float screenMiddleX;  // Middle of the screen in world coordinates
    private bool isFollowing = false;  // Whether the camera should follow the player

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to CameraFollow script.");
            return;
        }

        mainCamera = Camera.main;

        if (sala != null)
        {
            salaRenderer = sala.GetComponent<Renderer>();
        }

        // Calculate the screen's middle point in world coordinates
        screenMiddleX = mainCamera.transform.position.x;
    }

    void LateUpdate()
    {
        if (player == null || salaRenderer == null)
            return;

        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // If the player reaches the middle of the screen, lock the camera to follow them
        if (!isFollowing && Mathf.Abs(player.position.x - screenMiddleX) > 0.1f)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            // Directly set the camera to follow the player
            Vector3 targetPosition = transform.position;
            targetPosition.x = player.position.x;

            // Clamp within Sala's bounds
            targetPosition.x = Mathf.Clamp(targetPosition.x, Mathf.Max(0, salaRenderer.bounds.min.x + cameraHalfWidth), salaRenderer.bounds.max.x - cameraHalfWidth);

            // Instantly move the camera to the player when following starts
            transform.position = targetPosition;
        }
    }
}
