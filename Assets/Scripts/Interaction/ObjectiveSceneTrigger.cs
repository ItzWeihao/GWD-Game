using UnityEngine;

public class ObjectiveSceneTrigger : MonoBehaviour, IInteractable
{
    private FadeUI _fadeUI;
    [SerializeField] private bool _isActive = false;
    public Light exitLight;
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

    public void SetActive()
    {
        _isActive = true;
        exitLight.enabled = true;
    }
}
