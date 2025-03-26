using UnityEngine;

public class RobinPicture : MonoBehaviour, IInteractable
{
    public PictureManager _pictureManager;

    public void Interact()
    {
        Debug.Log("Robin picture");
        _pictureManager.CountInteractions();
        Destroy(gameObject);
    }
}
