using UnityEngine;

public class RobinPicture : MonoBehaviour
{
    public PictureManager _pictureManager;

    public Light[] lights;

    public void RobinPictureInteract()
    {
        _pictureManager.CountInteractions();
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
