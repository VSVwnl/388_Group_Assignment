using UnityEngine;
using UnityEngine.EventSystems;

public class FlashlightClickHandler : MonoBehaviour, IPointerClickHandler
{
    private ToggleLight toggleLight;

    private void Awake()
    {
        toggleLight = GetComponent<ToggleLight>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (toggleLight != null)
        {
            toggleLight.Flip();
        }
    }
}
