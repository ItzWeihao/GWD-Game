using UnityEngine;

public class ReverieCore : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject logs;

    private bool firstInteraction = true;

    public void ActivateLogObjective()
    {
        if (firstInteraction)
        {
            Debug.Log("Logs enabled");
            // 1. Make doors open
            door1.transform.Rotate(door1.transform.rotation.x, door1.transform.rotation.y - 95, door1.transform.rotation.z);
            door2.transform.Rotate(door2.transform.rotation.x, door2.transform.rotation.y - 95, door2.transform.rotation.z);

            // 2. Enable the logs
            logs.SetActive(true);

            // 3. Sound Implementation
            SoundManagerScript.PlaySound(SoundType.DOORSLAM);
        }
        // Makes sure that the door only rotates once and the logs are only set active once
        firstInteraction = false;
    }
}
