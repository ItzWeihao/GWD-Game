using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject quitConfirmationPanel;

    public bool isPaused = false;

    void Start()
    {
        pauseMenuUI = GameObject.Find("Pause");
        optionsMenuUI = GameObject.Find("Options");
        quitConfirmationPanel = GameObject.Find("QuitConfirmationPanel");

        pauseMenuUI.SetActive(false); // Hide menu at game start
        quitConfirmationPanel.SetActive(false); // Hide quit confirmation
        optionsMenuUI.SetActive(false);

        // Ensure the game is unpaused and the cursor is hidden/locked at the beginning
        Time.timeScale = 1f;
        isPaused = false;

        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        quitConfirmationPanel.SetActive(false); // Just in case
        optionsMenuUI.SetActive(false);

        Time.timeScale = 1f; // Resume time
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        quitConfirmationPanel.SetActive(false);

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
        // Show the confirmation panel instead of quitting immediately
        pauseMenuUI.SetActive(false);
        quitConfirmationPanel.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Debug.Log("Quit confirmed!");
        Application.Quit();
    }

    public void CancelQuit()
    {
        // Hide the confirmation and return to the pause menu
        quitConfirmationPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void OnOptionsClick()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void OnBackClick()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void menuEnableController(bool state)
    {
        pauseMenuUI.SetActive(state);
        quitConfirmationPanel.SetActive(state);
        optionsMenuUI.SetActive(state);
    }
}
