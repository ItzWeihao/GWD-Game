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
            monster.transform.position = new Vector3(-20f, 0f, -1f);
            monster.transform.eulerAngles = new Vector3(0, 270f, 0);
        }
    }
}
