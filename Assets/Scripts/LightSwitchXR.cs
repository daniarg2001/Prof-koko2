using UnityEngine;
using System; 
public class LightSwitchXR : MonoBehaviour
{
    public Transform switchHandle;
    public Vector3 onRotation = new Vector3(0, 0, 0);
    public Vector3 offRotation = new Vector3(90, 0, 0);
    private bool isOn = false; // Estado atual do interruptor

    // notificar a mudanca de estado
    public event Action<bool> OnSwitchToggled;

    
    public bool IsOn
    {
        get { return isOn; }
    }

    public void ToggleSwitch()
    {
        isOn = !isOn;
        RotateHandle(isOn ? onRotation : offRotation);

        // acionar o evento
        OnSwitchToggled?.Invoke(isOn);
    }

    void RotateHandle(Vector3 newRotation)
    {
        switchHandle.localEulerAngles = newRotation; // altera a rotacao do manipulador
    }
}
