using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 

public class InteractableController : MonoBehaviour
{
    private XRBaseInteractable interactable;
    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>(); // Referencia do componente com interacao
    }

    public void SetInteractable(bool state)
    {
        if (interactable != null)
        {
            interactable.enabled = state; // Ativar desativar a interacao
        }
    }
}
