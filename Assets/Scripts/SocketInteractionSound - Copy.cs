using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteractionSoundAndMaterial : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip clip; 
    public string[] acceptableTags; 
    private SocketController socketController; 

    

    void Start()
    {
        // Obter o XR Socket Interactor do objeto
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        if (socket != null)
        {
            socket.selectEntered.AddListener(OnSelectEntered);
            socket.selectExited.AddListener(OnSelectExited);
        }

        // Encontrar o SocketController na cena
        socketController = FindObjectOfType<SocketController>();
    }

    private void OnSelectEntered(SelectEnterEventArgs arg)
    {
        GameObject obj = arg.interactableObject.transform.gameObject;
        if (audioSource != null && clip != null && IsAcceptable(obj))
        {
            audioSource.PlayOneShot(clip);
            socketController.UpdateSocketState(true);
        }
    }

    private void OnSelectExited(SelectExitEventArgs arg)
    {
        GameObject obj = arg.interactableObject.transform.gameObject;
        if (IsAcceptable(obj))
        {
            socketController.UpdateSocketState(false);
        }
    }

    private bool IsAcceptable(GameObject obj)
    {
        foreach (string tag in acceptableTags)
        {
            if (obj.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }

    private void OnDestroy()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        if (socket != null)
        {
            socket.selectEntered.RemoveListener(OnSelectEntered);
            socket.selectExited.RemoveListener(OnSelectExited);
        }
        
    }
}
