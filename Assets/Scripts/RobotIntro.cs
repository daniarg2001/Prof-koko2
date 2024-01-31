using UnityEngine;
using System.Collections.Generic;

public class RobotIntro : MonoBehaviour
{
    public Animator robotAnimator;
    public string introAnimationName;

    void Start()
    {
        SetAllInteractables(false); // Desativa a interacao
        robotAnimator.Play(introAnimationName);
        Invoke("EnableInteractions", robotAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }

    void EnableInteractions()
    {
        SetAllInteractables(true); // reativa a interacao
    }

    void SetAllInteractables(bool state)
    {
        foreach (var interactable in FindObjectsOfType<InteractableController>())
        {
            interactable.SetInteractable(state);
        }
    }
}
