using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonAnimationController : MonoBehaviour
{
    public Animator childAnimator; // Referência ao Animator do filho

    void Awake()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(TriggerAnimation);
    }

    private void TriggerAnimation(XRBaseInteractor interactor)
    {
        childAnimator.SetTrigger("Press"); // Aciona a animação
    }

    void OnDestroy()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.RemoveListener(TriggerAnimation);
    }
}
