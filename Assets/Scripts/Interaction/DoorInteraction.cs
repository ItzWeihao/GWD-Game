using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator doorAnimation = null;

    [SerializeField] private bool open = false;

    public void Interact()
    {
        if (open)
        {
            doorAnimation.Play("DoorsClose", 0, 0.0f);
            open = false;
        }
        else if (!open)
        {
            doorAnimation.Play("DoorsOpen", 0, 0.0f);
            open = true;
        }
    }
}
