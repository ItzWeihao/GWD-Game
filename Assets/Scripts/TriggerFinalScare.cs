using System.Threading;
using UnityEngine;

public class TriggerFinalScare : MonoBehaviour, IInteractable
{
    public GameObject player;
    public float smooth = 1f;

    private Quaternion targetRotation;
    public PlayerMovement PlayerMovement;
    public MonsterScareLoop4 run;

    public LightFlicker lightFlicker;
    public Light _light1;
    public Light _light2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (lightFlicker == null)
        //{
        //    lightFlicker = FindFirstObjectOfType<LightFlicker>();  // Find the LightFlicker script in the scene
        //}
    }

    public void Interact()
    {
        
        PlayerMovement.StopPlayerMovement();
        player.transform.eulerAngles = new Vector3(0, 90f, 0);

        _light2.enabled = false;
        Transform camera = player.transform.Find("PlayerCamera");
        camera.localEulerAngles = new Vector3(0f, 0f, 0f);
        //camera.transform.position = new Vector3(0.48f, 1.917f, 0.7f);
        run.StartScareSequence();
        if (lightFlicker != null)
        {
            lightFlicker.StartFlickering();  // Start flickering the light
        }
    }
}
