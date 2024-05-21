using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class SpinRecord : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private bool isRotating = false;
    [SerializeField] private GameObject handle;
    public Vector3 targetRotation = new Vector3(-1.805f, 50f, 0f);
    public Vector3 targetPosition = new Vector3(-0.108367f, 0.05f, -0.03527069f);

    [SerializeField] private XRSocketInteractor socketInteractor;

    private void OnEnable()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnSelectEntered);
            socketInteractor.selectExited.AddListener(OnSelectExit);
        }
    }

    private void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    PlayContinuousSound cd = null;
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log(name + "is called" + args.interactableObject.transform.name);
        
        {
            PlayContinuousSound cd = args.interactableObject.transform.GetComponent<PlayContinuousSound>();
            cd.Play();
            if (this.cd != null)
            {
                this.cd.Pause();
            }
            this.cd = cd;
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        Debug.Log(name + "is called" + args.interactableObject.transform.name);

        {
            if (this.cd != null)
            {
                this.cd.Pause();
            }
            this.cd = null;
        }
    }

    public void StartRotation()
    {
        if (handle != null)
        {
            // Start spinning the record
            isRotating = true;

            handle.transform.localRotation = Quaternion.Euler(targetRotation);
            handle.transform.localPosition = targetPosition;
        }
    }

    public void StopRotation()
    {
        if (handle != null)
        {
            // Stop spinning the record
            isRotating = false;

            handle.transform.localRotation = Quaternion.Euler(-1.805f, 0f, 0f);
            handle.transform.localPosition = targetPosition;
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
