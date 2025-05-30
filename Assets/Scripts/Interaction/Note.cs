using DialogueEditor;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool active = true;

    public void setActive() {  active = false; }

    [SerializeField] private Light hintLight;

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

    public void EnableHintLight()
    {
        hintLight.enabled = true;
    }
}
