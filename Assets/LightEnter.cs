using UnityEngine;

public class LightEnter : MonoBehaviour
{
    public Light light1;

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "Monster1")
        {
            light1.enabled = true;
        }
    }
}
