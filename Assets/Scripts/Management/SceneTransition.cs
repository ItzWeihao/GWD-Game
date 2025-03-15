using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    protected int sceneIndex = 0;
    public void SwitchScene(int newSceneIndex)
    {
        SceneManager.LoadScene(newSceneIndex);
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }

    public void SetSceneIndex(int currentSceneIndex)
    {
        sceneIndex = currentSceneIndex;
    }
}
