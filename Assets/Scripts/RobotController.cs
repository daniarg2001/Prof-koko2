using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour
{
    public Animator robotAnimator;
    public AudioSource audioSource;
    public AudioClip correctCircuitSound; // som de teste para circuito ligado corretamente
    public AudioClip incorrectCircuitSound; // som de teste para circuito incorreto
    public string approachAnimationName;
    public string returnAnimationName;
    public SocketController socketController; // referencia do SocketController

    private bool isInteracting = false;

    public void CallProfessor()
    {
        if (!isInteracting)
        {
            StartCoroutine(InteractWithProfessor());
        }
    }

    private IEnumerator InteractWithProfessor()
    {
        isInteracting = true;
        robotAnimator.Play(approachAnimationName);
        yield return new WaitUntil(() => robotAnimator.GetCurrentAnimatorStateInfo(0).IsName(approachAnimationName));
        yield return new WaitWhile(() => robotAnimator.GetCurrentAnimatorStateInfo(0).IsName(approachAnimationName) && robotAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);

        AudioClip clipToPlay = socketController.IsCircuitCorrect() ? correctCircuitSound : incorrectCircuitSound; // escolhe o som tendo em conta a condicao do circuito
        audioSource.PlayOneShot(clipToPlay);

        yield return new WaitForSeconds(clipToPlay.length);
        robotAnimator.Play(returnAnimationName);
        yield return new WaitUntil(() => robotAnimator.GetCurrentAnimatorStateInfo(0).IsName(returnAnimationName));
        yield return new WaitWhile(() => robotAnimator.GetCurrentAnimatorStateInfo(0).IsName(returnAnimationName) && robotAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);

        isInteracting = false;
    }
}
