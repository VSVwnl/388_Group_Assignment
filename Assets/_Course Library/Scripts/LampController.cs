using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LampController : MonoBehaviour
{
    public Light lampLight; // Reference to the Light component of the lamp
    private bool isOn = false; // Flag to track lamp state

    private void Start()
    {
        // Ensure lamp light is initially turned off
        lampLight.enabled = false;
    }

    public void ToggleLamp()
    {
        // Toggle lamp state and light
        isOn = !isOn;
        lampLight.enabled = isOn;
    }
}

