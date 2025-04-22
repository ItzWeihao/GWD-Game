using UnityEngine;

public class JumpscareTrigger1 : MonoBehaviour
{
    public Light light1;

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "PlayerObject")
        {
            light1.enabled = true;
        }
    }
}
