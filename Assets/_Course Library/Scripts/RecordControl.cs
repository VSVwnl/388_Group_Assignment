using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordControl : MonoBehaviour
{
    public GameObject record; // Reference to the record GameObject
    private SpinRecord recordScript; // Reference to the SpinRecord script on the record GameObject

    private void Start()
    {
        // Get the SpinRecord script from the record GameObject
        recordScript = record.GetComponent<SpinRecord>();
        if (recordScript == null)
        {
            Debug.LogError("SpinRecord component not found on the record GameObject.");
        }
    }

    private void OnSelectEntered(XRBaseInteractable interactable)
    {
        // Check if the attached GameObject is the record
        if (interactable.gameObject == record)
        {
            // Start spinning the record
            if (recordScript != null)
            {
                recordScript.StartSpinning();
            }
            else
            {
                Debug.LogError("SpinRecord script not found.");
            }
        }
    }
}
