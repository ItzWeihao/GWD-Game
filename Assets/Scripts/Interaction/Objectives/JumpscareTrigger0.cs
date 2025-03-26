using UnityEngine;

public class JumpscareTrigger0 : MonoBehaviour
{
    public Light light1;

    public GameObject monster;

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "PlayerObject")
        {
            light1.enabled = false;

            monster.SetActive(false);
        }
    }
}
