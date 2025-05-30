using UnityEngine;
using UnityEngine.SceneManagement;

public class GammaCameraConnector : MonoBehaviour
{
    public GammaChanger _gammaChanger;
    private float gammaValue;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 7)
        {
            _gammaChanger = GameObject.Find("PlayerCamera").GetComponent<GammaChanger>();
        }
    }

    public void GammaValue(float value)
    {
        gammaValue = value;
        _gammaChanger.AdjustGamma(value);
    }

    private void Update()
    {
        if (_gammaChanger == null && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 7)
        {
            _gammaChanger = GameObject.Find("PlayerCamera").GetComponent<GammaChanger>();
            GammaValue(gammaValue);
        }
    }
}
