using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleControl : MonoBehaviour
{
    public Vector3 targetRotation = new Vector3(-1.805f, 50f, 0f);
    public Vector3 targetPosition = new Vector3(-0.18f, 0.01f, -0.05f);

    private XRSocketInteractor socketInteractor;

    private void OnEnable()
    {
        socketInteractor = GetComponentInParent<XRSocketInteractor>();
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform == transform)
        {
            AdjustRotationAndPosition();
        }
    }

    public void AdjustRotationAndPosition()
    {
        // Adjust the rotation and position
        transform.localRotation = Quaternion.Euler(targetRotation);
        transform.localPosition = targetPosition;
    }
}
