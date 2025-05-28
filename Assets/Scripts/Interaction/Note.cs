using DialogueEditor;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool active = true;

    public void setActive() {  active = false; }

    public void checkActive()
    {
        if (!active)
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                ConversationManager.Instance.SetBool("active", active);
            }
        }
    }
}
