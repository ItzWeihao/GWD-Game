using DialogueEditor;
using UnityEngine;

public class RobinPicture : MonoBehaviour, IInteractable
{
    public PictureManager _pictureManager;
    public PlayerMovement playerMovement;
    private NPCConversation _npcConversation;

    void Awake()
    {
        _npcConversation = GetComponent<NPCConversation>();
    }

    public void Interact()
    {
        playerMovement.CursorSetting(0, true);
        playerMovement.StopPlayerMovement();
        playerMovement.inDialogue = true;
        ConversationManager.Instance.StartConversation(_npcConversation);
        _pictureManager.CountInteractions();
        if (!ConversationManager.Instance.IsConversationActive && playerMovement.inDialogue)
        {
            playerMovement.inDialogue = false;
            playerMovement.ResumePlayerMovement();
            playerMovement.CursorSetting(CursorLockMode.Locked, false);
            Destroy(gameObject);
        }
    }
}
