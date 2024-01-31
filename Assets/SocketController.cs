using UnityEngine;

public class SocketController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip completionClip;
    private int totalSockets;
    private int correctSockets;

    public LightSwitchXR lightSwitch; 
    public Material lampOnMaterial; 
    public Material lampOffMaterial; 

    void Start()
    {
        totalSockets = FindObjectsOfType<SocketInteractionSoundAndMaterial>().Length;
        correctSockets = 0;

        if (lightSwitch != null)
        {
            lightSwitch.OnSwitchToggled += HandleSwitchToggle;
        }
    }

    public void UpdateSocketState(bool correct)
    {
        if (correct)
        {
            correctSockets++;
        }
        else
        {
            correctSockets--;
        }

        CheckAllSocketsCorrect();
    }

    private void CheckAllSocketsCorrect()
    {
        if (IsCircuitCorrect())
        {
            PlayCompletionSound();
            SetLampsMaterial(lampOnMaterial);
        }
        else
        {
            SetLampsMaterial(lampOffMaterial);
        }
    }

    public bool IsCircuitCorrect()
    {
        return correctSockets == totalSockets && lightSwitch != null && lightSwitch.IsOn;
    }

    private void SetLampsMaterial(Material material)
    {
        foreach (GameObject lamp in GameObject.FindGameObjectsWithTag("lamp"))
        {
            Renderer lampRenderer = lamp.GetComponent<Renderer>();
            if (lampRenderer != null)
            {
                lampRenderer.material = material;
            }
        }
    }

    private void HandleSwitchToggle(bool isOn)
    {
        CheckAllSocketsCorrect();
    }

    private void PlayCompletionSound()
    {
        if (IsCircuitCorrect())
        {
            audioSource.PlayOneShot(completionClip);
        }
    }

    void OnDestroy()
    {
        if (lightSwitch != null)
        {
            lightSwitch.OnSwitchToggled -= HandleSwitchToggle;
        }
    }
}
