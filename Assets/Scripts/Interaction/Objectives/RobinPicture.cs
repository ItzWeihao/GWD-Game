using UnityEngine;

public class RobinPicture : MonoBehaviour
{
    public PictureManager _pictureManager;

    public GameObject _voiceMemo;

    public void RobinPictureInteract()
    {
        _pictureManager.CountInteractions();
        _voiceMemo.SetActive(true);
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
