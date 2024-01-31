using UnityEngine;

public class AnimateOnGrab : MonoBehaviour
{
    public Animator animator;
    public string animationTrigger = "Activate";

    public void TriggerAnimation()
    {
        animator.SetTrigger(animationTrigger);
    }
}

