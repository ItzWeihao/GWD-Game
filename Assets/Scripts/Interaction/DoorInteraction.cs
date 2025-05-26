using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private Animator animator;
    public bool open = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (open)
        {
            animator.Play("Close");
            open = false;
        } else if (!open)
        {
            animator.Play("Open");
            open = true;
        }
    }
}
