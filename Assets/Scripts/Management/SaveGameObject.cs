using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameObject : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
