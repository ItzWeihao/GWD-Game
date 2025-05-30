using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{
    public Animator endCreditAnimation;

    public GameObject endButton;

    public GameObject GameManager;
    public GameObject SceneManagerObject;

    private void Start()
    {
        GameManager = GameObject.Find("=== GameManager ===");
        SceneManagerObject = GameObject.Find("=== SceneManager ===");
        Cursor.lockState = 0;
        Cursor.visible = true;
    }

    void Update()
    {
        if (endCreditAnimation.GetCurrentAnimatorStateInfo(0).length > endCreditAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            if (endButton != null)
            {
                endButton.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        Destroy(GameManager);
        Destroy(SceneManagerObject);
        SceneManager.LoadScene(0);
    }
}
