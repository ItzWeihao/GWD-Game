using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public Transform _target;
    public int RotationSpeed;
    private bool open = false;
    private Quaternion currentRotation;
    
    void Start()
    {
        currentRotation = transform.rotation;
    }

    public void Interact()
    {
        
        if (!open)
        {
            transform.rotation = Quaternion.RotateTowards(currentRotation, _target.rotation, RotationSpeed);
            open = true;
        } 
        else if (open)
        {
            transform.rotation = Quaternion.RotateTowards(_target.rotation, currentRotation, RotationSpeed);
            open = false;
        }
    }
}
