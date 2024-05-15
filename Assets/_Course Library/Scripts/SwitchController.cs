using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchControllerXR : MonoBehaviour
{
    public FanController fanController;

    private XRBaseInteractable interactable;

    private void Awake()
    {
        // Ensure the XRBaseInteractable component is attached
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable == null)
        {
            interactable = gameObject.AddComponent<XRBaseInteractable>();
        }
    }

    private void OnEnable()
    {
        // Subscribe to the select entered event
        interactable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        // Unsubscribe from the select entered event
        interactable.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Call the ToggleFan method when the switch is selected
        fanController.ToggleFan();
    }
}
