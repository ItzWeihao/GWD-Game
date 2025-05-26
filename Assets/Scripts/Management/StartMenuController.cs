using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void OnStartClick()
    {
        SceneManager.LoadScene("Intro");
    }
    public void OnOptionsClick()
    {
        pauseMenuUI.SetActive(true);
    }
    public void OnBackClick()
    {
        pauseMenuUI.SetActive(false);
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
