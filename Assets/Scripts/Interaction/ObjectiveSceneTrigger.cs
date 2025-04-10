using DialogueEditor;
using UnityEngine;

public class ObjectiveSceneTrigger : MonoBehaviour, IInteractable
{
    public PlayerMovement PlayerMovement;

    private FadeUI _fadeUI;
    private bool _isActive = false;
    private NPCConversation _dialogue;
    void Awake()
    {
        _fadeUI = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();
        _dialogue = GetComponent<NPCConversation>();
    }

    public void Interact()
    {
        if (_isActive)
        {
            _fadeUI.Fade();
        } else
        {
            PlayerMovement.CursorSetting(0, true);
            PlayerMovement.StopPlayerMovement();
            PlayerMovement.inDialogue = true;
            ConversationManager.Instance.StartConversation(_dialogue);
        }
    }

    public bool SetActive()
    {
        return _isActive = true;
    }
}
