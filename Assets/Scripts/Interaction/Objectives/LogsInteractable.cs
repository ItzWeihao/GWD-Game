using DialogueEditor;
using UnityEngine;

public class LogsInteractable : MonoBehaviour, IInteractable
{
    [Header("GameObjects")]
    public GameObject Log;

    [Header("Scripts")]
    public LogsManager _logsManager;
    public PlayerMovement PlayerMovement;

    private NPCConversation _npcConversation;

    [Header("Variables")]
    private bool hasInteracted;

    private void Awake()
    {
        hasInteracted = false;
        _npcConversation = GetComponent<NPCConversation>();
    }

    public void Interact()
    {
        PlayerMovement.CursorSetting(0, true);
        PlayerMovement.StopPlayerMovement();
        Log.SetActive(true);

        // Open the logs
        if (!ConversationManager.Instance.IsConversationActive)
        {
            PlayerMovement.inDialogue = true;
            ConversationManager.Instance.StartConversation(_npcConversation);
            if (hasInteracted)
            {
                ConversationManager.Instance.SetBool("FirstInteraction", false);
            }
        }

        if (!hasInteracted)
        {
            hasInteracted = true;
            _logsManager.CountInteractions();
        }
    }
}
