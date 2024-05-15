using UnityEngine;

public class FanController : MonoBehaviour
{
    public float maxSpeed = 360f; // Maximum speed in degrees per second
    public float acceleration = 30f; // How quickly the fan reaches max speed
    private float currentSpeed = 0f;
    private bool isOn = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the fan is supposed to be on or off
        if (isOn && currentSpeed < maxSpeed)
        {
            // Gradually increase the speed
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (!isOn && currentSpeed > 0)
        {
            // Gradually decrease the speed
            currentSpeed -= acceleration * Time.deltaTime;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        // Rotate the fan blades around the correct axis
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime, Space.Self);
    }

    // Method to turn the fan on or off
    public void ToggleFan()
    {
        isOn = !isOn;
    }
}
