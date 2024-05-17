using UnityEngine;

public class SpinRecord : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private bool isRotating = false;

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}