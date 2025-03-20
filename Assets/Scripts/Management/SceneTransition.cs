using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    protected int sceneIndex;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void SwitchScene()
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }
}
