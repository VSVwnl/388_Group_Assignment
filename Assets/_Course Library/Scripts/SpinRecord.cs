using UnityEngine;

public class SpinRecord : MonoBehaviour
{
    public float maxSpeed = 100f; // Maximum speed in degrees per second
    public float acceleration = 30f; // How quickly the record reaches max speed
    private float currentSpeed = 0f;
    private bool isSpinning = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the record should be spinning
        if (isSpinning && currentSpeed < maxSpeed)
        {
            // Gradually increase the speed
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (!isSpinning && currentSpeed > 0)
        {
            // Gradually decrease the speed
            currentSpeed -= acceleration * Time.deltaTime;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        // Rotate the record around its Y-axis
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }

    // Method to start spinning the record
    public void StartSpinning()
    {
        isSpinning = true;
        Debug.Log("Record spinning started.");
    }

    public void StopSpinning()
    {
        isSpinning = false;
        Debug.Log("Record spinning stopped.");
    }

}
