using UnityEngine;

public class LogsInteractable : MonoBehaviour
{
    public LogsManager _logsManager;
    private bool hasInteracted;

    private void Awake()
    {
        hasInteracted = false;
    }

    public void activateLog()
    {
        if (!hasInteracted)
        {
            hasInteracted = true;
            _logsManager.CountInteractions();
        }
        // Open the logs
        Debug.Log("You've opened this log");
    }
}
