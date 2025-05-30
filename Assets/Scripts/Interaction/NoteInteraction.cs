using DialogueEditor;
using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    private NPCConversation _npcConversation;
    private bool active;

    public void setActive()
    {
        active = true;
    }

    public void cellConversation()
    {
        if (active)
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                Debug.Log("should set active");
                ConversationManager.Instance.SetBool("active", active);
            }
        }
    }
}
