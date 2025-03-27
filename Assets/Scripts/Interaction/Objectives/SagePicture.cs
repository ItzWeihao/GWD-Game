using UnityEngine;

public class SagePicture : MonoBehaviour, IInteractable
{
    public PictureManager _pictureManager;
    private bool hasInteracted;

    private void Awake()
    {
        hasInteracted = false;
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            hasInteracted = true;
            _pictureManager.CountInteractions();
            // put down Robins Picture
            // play voice recorder
        }
        Debug.Log("Sage picture");
    }
}
