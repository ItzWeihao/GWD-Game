using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("This is " + gameObject.name);
    }
}
