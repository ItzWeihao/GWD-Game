using JetBrains.Annotations;
using UnityEngine;

public class TriggerMonsterScare1 : MonoBehaviour
{
    public MonsterScare1 run;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "Player")
        {
            run.movingToTarget = true;
            Destroy(gameObject);
        }
    }
}
