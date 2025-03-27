using UnityEngine;

public class LogsInteractable : MonoBehaviour, IInteractable
{
    public LogsManager _logsManager;
    private bool hasInteracted;

    private void Awake()
    {
        hasInteracted = false;
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            hasInteracted = true;
            _logsManager.CountInteractions();
        }
        // Open the logs
        Debug.Log("You've open this log");
    }
}
