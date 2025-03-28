using UnityEngine;

public class MonsterScare1 : MonoBehaviour
{
    public float speed;
    public Transform current;
    public Transform target;
    public bool movingToTarget = false;

    public Light _light1;
    public Light _light2;
    public PlayerMovement _playerMovement;
    public GameObject door1;
    public GameObject door2;
    public GameObject picture;

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
            _light1.intensity = 0.5f;
            _light2.intensity = 1f;

            _playerMovement.enabled = true;
            picture.SetActive(true);
            // Play Door breaking sound
            Debug.Log("Door break sound");
            Destroy(door1);
            Destroy(door2);

            Destroy(gameObject);
        }
        
    }
}
