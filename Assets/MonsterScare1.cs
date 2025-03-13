using UnityEngine;

public class MonsterScare1 : MonoBehaviour
{
    public float speed;
    public Transform current;
    public Transform target;
    public bool movingToTarget = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (movingToTarget == true)
        {
            Run();
        }
        
    }
    public void Run()
    {
        transform.position = Vector3.MoveTowards(current.position, target.position, speed * Time.deltaTime);
        
        if (current.position == target.position)
        {
            Destroy(gameObject);
        }
        
    }
}
