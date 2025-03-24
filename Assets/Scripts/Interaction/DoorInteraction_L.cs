using UnityEngine;

public class DoorInteraction_L : MonoBehaviour, IInteractable
{
    private new Transform transform;
    private Quaternion doorStart;
    private bool doorOpen;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        doorStart = transform.rotation;
        doorOpen = false;
    }

    public void Interact()
    {
        if (doorOpen == false)
        {
            transform.Rotate(0, 285 - doorStart.y, 0);
            doorOpen = true;
        } else
        {
            transform.Rotate(0, doorStart.y + 75, 0);
            doorOpen = false;
        }
    }
}
