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
    public GameObject door;
    public GameObject picture;
    public Animator animator;

    // Update is called once per frame
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        if (movingToTarget == true)
        {
            Run();
        }
        
    }
    public void Run()
    {
        animator.SetBool("RUN", true);
        transform.position = Vector3.MoveTowards(current.position, target.position, speed * Time.deltaTime);
        
        if (current.position == target.position)
        {
            _light1.intensity = 0.5f;
            _light2.intensity = 1f;

            animator.SetBool("RUN", false);
            
            picture.SetActive(true);

            SoundManagerScript.PlaySound(SoundType.DOORIMPACT);
            Destroy(door);

            Destroy(gameObject);

            _playerMovement.ResumePlayerMovement();
        }
        
    }
}
