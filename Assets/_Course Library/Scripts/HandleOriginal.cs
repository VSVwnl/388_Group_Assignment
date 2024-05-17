using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleOriginal: MonoBehaviour
{
    public Vector3 targetRotation = new Vector3(-1.805f, 0f, 0f);

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
    }
}
