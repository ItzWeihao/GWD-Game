using UnityEngine;

public class ObjectiveSceneTrigger : MonoBehaviour, IInteractable
{
    private FadeUI _fadeUI;
    private bool _isActive = false;
    void Awake()
    {
        _fadeUI = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();
    }

    public void Interact()
    {
        if (_isActive)
        {
            _fadeUI.Fade();
        }
    }

    public bool SetActive()
    {
        return _isActive = true;
    }
}
