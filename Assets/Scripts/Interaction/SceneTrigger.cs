using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour, IInteractable
{
    private FadeUI _fadeUI;
    [SerializeField] private Animator transitionDoorAnimation = null;

    private void Awake()
    {
        _fadeUI = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();
    }

    public void Interact()
    {
        // We set the current Scene Index and switch to that scene
        transitionDoorAnimation.Play("SceneTransitionDoor", 0, 0.0f);
        _fadeUI.Fade();
    }
}
