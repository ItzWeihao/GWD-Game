using UnityEngine;

public class ReverieCore : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject log1;
    [SerializeField] private GameObject log2;
    [SerializeField] private GameObject log3;

    public void Interact()
    {
        // 1. Make doors open
        door1.transform.Rotate(door1.transform.rotation.x, door1.transform.rotation.y - 95, door1.transform.rotation.z);
        door2.transform.Rotate(door2.transform.rotation.x, door2.transform.rotation.y - 95, door2.transform.rotation.z);

        // 2. Enable the logs
        log1.SetActive(true);
        log2.SetActive(true);
        log3.SetActive(true);

        // 3. Sound Implementation

    }
}
