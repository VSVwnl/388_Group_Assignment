using UnityEngine;

public class CrosshairScaler : MonoBehaviour
{
    public Camera vrCamera; // The VR camera
    public GameObject reticleImage; // The reticle image as a GameObject
    public float minScale = 0.1f; // Minimum scale of the reticle
    public float maxScale = 1.0f; // Maximum scale of the reticle
    public float minDistance = 0.5f; // Minimum distance at which the reticle starts scaling
    public float maxDistance = 10.0f; // Maximum distance at which the reticle stops scaling

    void Update()
    {
        // Perform a raycast from the center of the camera
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the distance to the hit object
            float distance = hit.distance;

            // Calculate the scale factor based on distance
            float scaleFactor = Mathf.Lerp(maxScale, minScale, Mathf.InverseLerp(minDistance, maxDistance, distance));

            // Apply the scale factor to the reticle
            reticleImage.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
        else
        {
            // If nothing is hit, set the reticle to its minimum scale
            reticleImage.transform.localScale = new Vector3(minScale, minScale, minScale);
        }
    }
}
