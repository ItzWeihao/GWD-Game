using UnityEngine;

public class TriggerFinalScare : MonoBehaviour, IInteractable
{
    public GameObject player;
    public float smooth = 1f;

    private Quaternion targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        targetRotation = Quaternion.LookRotation(-transform.forward, Vector3.up);

        player.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);
    }
}
