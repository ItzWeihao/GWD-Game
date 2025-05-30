using System.Collections;
using UnityEngine;

public class MonsterScareLoop4 : MonoBehaviour
{
    public float speed;
    public Transform current;
    public Transform target;
    public bool movingToTarget = false;

    public Animator animator;
    public FadeToBlack fadeController;
    [SerializeField] private FadeUI sceneTransition;

    public float delayBeforeRun = 2f; // Seconds to wait before running

    public AudioSource scream;

    private void Awake()
    {
        sceneTransition = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();
        animator = GetComponent<Animator>();
        scream = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (movingToTarget)
        {
            Run();
        }
    }

    public void StartScareSequence()
    {
        StartCoroutine(DelayedRun());
    }

    private IEnumerator DelayedRun()
    {
        yield return new WaitForSeconds(delayBeforeRun);  // Wait for X seconds
        scream.Play();
        movingToTarget = true;
    }

    private void Run()
    {
        animator.SetBool("RUN", true);

        Vector3 direction = (target.position - current.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: stop moving if reached the target
        if (Vector3.Distance(transform.position, target.position) < 1.5f)
        {
            movingToTarget = false;
            animator.SetBool("RUN", false);
            sceneTransition.Fade();
        }
    }
}
