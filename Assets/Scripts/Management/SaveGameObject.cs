using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameObject : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }
}
