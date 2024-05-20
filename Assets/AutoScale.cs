using UnityEngine;
using System.Collections;

public class AutoScale : MonoBehaviour
{
    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(2, 2, 2);
    public float duration = 2.0f;

    private bool scalingUp = true;
    private float timer = 0f;

    void Start()
    {
        StartCoroutine(ScaleObject());
    }

    IEnumerator ScaleObject()
    {
        while (true)
        {
            Vector3 startScale = scalingUp ? minScale : maxScale;
            Vector3 endScale = scalingUp ? maxScale : minScale;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float normalizedTime = t / duration;
                transform.localScale = Vector3.Lerp(startScale, endScale, normalizedTime);
                yield return null;
            }

            // Ensure the scale is set to the endScale
            transform.localScale = endScale;

            // Toggle the scaling direction
            scalingUp = !scalingUp;

            // Wait for a brief moment before starting the next scale
            yield return new WaitForSeconds(0.5f); // Optional delay
        }
    }
}
