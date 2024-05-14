using UnityEngine;

/// <summary>
/// Toggles a light
/// </summary>
public class ToggleLight : MonoBehaviour
{
    [Tooltip("Controls the state of the light")]
    public bool isOn = false;

    [Tooltip("Reference to the Light component to toggle")]
    public Light flashlightLight;

    private void Awake()
    {
        // Ensure we have a reference to the light component
        if (flashlightLight == null)
        {
            flashlightLight = GetComponentInChildren<Light>();
        }
    }

    private void Start()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isOn;
        }
    }

    public void TurnOn()
    {
        isOn = true;
        UpdateLight();
    }

    public void TurnOff()
    {
        isOn = false;
        UpdateLight();
    }

    public void Flip()
    {
        isOn = !isOn;
        UpdateLight();
    }

    private void UpdateLight()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isOn;
        }
    }

    private void OnValidate()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isOn;
        }
    }
}
