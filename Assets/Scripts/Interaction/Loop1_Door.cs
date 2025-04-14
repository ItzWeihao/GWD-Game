using DialogueEditor;
using UnityEngine;

public class Loop1_Door : MonoBehaviour, IInteractable
{
    public PlayerMovement PlayerMovement;


    private NPCConversation _npcConversation;

    [SerializeField] private int count;

    void Awake()
    {
        _npcConversation = GetComponent<NPCConversation>();
        count = 0;
    }

    public void Interact()
    {
        if (!ConversationManager.Instance.IsConversationActive)
        {
            PlayerMovement.inDialogue = true;
            ConversationManager.Instance.StartConversation(_npcConversation);
            if (count == 1)
            {
                ConversationManager.Instance.SetBool("Rage", true);
            } else
            {
                count++;
            }
        }
    }
}
