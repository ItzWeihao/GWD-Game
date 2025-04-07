using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Hide menu at game start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
    }

    public void GoToMainMenu()
    {
        Debug.Log("menu clicked!");

        Time.timeScale = 1f; // Reset time before changing scene
        SceneManager.LoadScene("Main_Menu"); // Replace with your menu scene name
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Optional
        Application.Quit();
        Debug.Log("Quit game!");
    }
}
