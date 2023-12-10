using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class cavaloScript : MonoBehaviour
{
    public TimerController timerController;

    void Start()
    {
        // Get all XRGrabInteractable components from the children
        XRGrabInteractable[] grabInteractables = GetComponentsInChildren<XRGrabInteractable>();

        // Attach event listeners for when an object is grabbed
        foreach (XRGrabInteractable grabInteractable in grabInteractables)
        {
            grabInteractable.selectEntered.AddListener(OnObjectGrabbed);
        }
    }

    void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        // Start the timer when any object is grabbed
        timerController.StartTimer();
    }
}
