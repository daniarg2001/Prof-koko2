using UnityEngine;

public class PlaySoundOnToggle : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip toggleOnClip; // audio para tocar quando a alavanca for ligada

    void Start()
    {
        // obtem a referencia do LightSwitchXR 
        LightSwitchXR lightSwitch = GetComponent<LightSwitchXR>();
        if (lightSwitch != null)
        {
            lightSwitch.OnSwitchToggled += HandleSwitchToggle;
        }
    }

    private void HandleSwitchToggle(bool isOn)
    {
        if (isOn)
        {
            // toca som quando a alavanca e ligada
            audioSource.PlayOneShot(toggleOnClip);
        }
    }

    void OnDestroy()
    {
        // cancelar o evento
        LightSwitchXR lightSwitch = GetComponent<LightSwitchXR>();
        if (lightSwitch != null)
        {
            lightSwitch.OnSwitchToggled -= HandleSwitchToggle;
        }
    }
}
