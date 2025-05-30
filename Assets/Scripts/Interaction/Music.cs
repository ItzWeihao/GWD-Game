using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (!musicSource.isPlaying)
            {
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }
}
