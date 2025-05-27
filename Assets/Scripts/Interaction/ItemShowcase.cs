using UnityEngine;

public class ItemShowcase : MonoBehaviour
{
    public void SetItemShowcaseActive(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void SetItemShowcaseDeactive(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
