using UnityEngine;
using UnityEngine.SceneManagement;

public class GammaCameraConnector : MonoBehaviour
{
    public GammaChanger _gammaChanger;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            _gammaChanger = GameObject.Find("Main Camera").GetComponent<GammaChanger>();
        }
    }

    public void GammaValue(float value)
    {
        _gammaChanger.AdjustGamma(value);
    }
}
