using JetBrains.Annotations;
using UnityEngine;

public class TriggerMonsterScare1 : MonoBehaviour
{
    public MonsterScare1 run;
    public Light _light1;
    public Light _light2;

    public Camera _camera;

    private PlayerMovement playerMovement;

    void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "PlayerObject")
        {
            Debug.Log("Play scary sound");
            _light1.intensity = 0;
            _light2.intensity = 0;

            collidedObject.GetComponent<PlayerMovement>().enabled = false;

            run.movingToTarget = true;
            Destroy(gameObject);
        }
    }
}
