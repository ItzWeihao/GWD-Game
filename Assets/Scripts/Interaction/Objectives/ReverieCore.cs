using DialogueEditor;
using UnityEngine;

public class ReverieCore : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject logs;

    public GameObject Manual;

    public PlayerMovement PlayerMovement;

    private NPCConversation _npcConversation;

    private bool firstInteraction = true;

    void Awake()
    {
        _npcConversation = GetComponent<NPCConversation>();
    }

    public void Interact()
    {
        PlayerMovement.CursorSetting(0, true);
        PlayerMovement.StopPlayerMovement();
        Manual.SetActive(true);

        if (firstInteraction)
        {
            Debug.Log("Logs enabled");
            // 1. Make doors open
            door1.transform.Rotate(door1.transform.rotation.x, door1.transform.rotation.y - 95, door1.transform.rotation.z);
            door2.transform.Rotate(door2.transform.rotation.x, door2.transform.rotation.y - 95, door2.transform.rotation.z);

            door1.GetComponent<NPCConversation>().enabled = false;
            door2.GetComponent<NPCConversation>().enabled = false;

            // 2. Enable the logs
            logs.SetActive(true);
        }

        if (!ConversationManager.Instance.IsConversationActive)
        {
            PlayerMovement.inDialogue = true;
            ConversationManager.Instance.StartConversation(_npcConversation);
            if (!firstInteraction)
            {
                ConversationManager.Instance.SetBool("FirstInteraction", false);
            }
        }

        // Makes sure that the door only rotates once and the logs are only set active once
        firstInteraction = false;
    }

    public void DoorSound()
    {
        SoundManagerScript.PlaySound(SoundType.DOOROPEN);
    }
}
