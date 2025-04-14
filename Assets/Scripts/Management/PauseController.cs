using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Hide menu at game start

        // Ensure the game is unpaused and the cursor is hidden/locked at the beginning
        Time.timeScale = 1f;
        isPaused = false;

        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze time
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToMainMenu()
    {
        Debug.Log("menu clicked!");

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reset time before changing scene
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game!");
        //Time.timeScale = 1f;
        Application.Quit();
    }
}
