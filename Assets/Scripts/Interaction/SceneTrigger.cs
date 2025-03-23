using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour, IInteractable
{
    private FadeUI _fadeUI;

    private void Start()
    {
        _fadeUI = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();
    }

    public void Interact()
    {

        // We set the current Scene Index and switch to that scene
        _fadeUI.Fade();
    }
}
