using UnityEngine;

public class ReticleScaler : MonoBehaviour
{
    public Transform playerCamera; // Reference to the VR camera
    public Transform teleportationArea; // Reference to the teleportation area
    public Transform reticle; // Reference to the reticle
    public float minScale = 0.5f; // Minimum scale of the reticle
    public float maxScale = 2.0f; // Maximum scale of the reticle
    public float minDistance = 1.0f; // Minimum distance for scaling
    public float maxDistance = 10.0f; // Maximum distance for scaling

    void Update()
    {
        // Calculate the distance between the player and the teleportation area
        float distance = Vector3.Distance(playerCamera.position, teleportationArea.position);

        // Clamp the distance to be within the min and max distance range
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Calculate the scale factor based on the distance
        float scaleFactor = Mathf.Lerp(minScale, maxScale, (distance - minDistance) / (maxDistance - minDistance));

        // Apply the scale factor to the reticle
        reticle.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
