using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.Universal;

public class GammaChanger : MonoBehaviour
{
    private LiftGammaGain gamma;
    private Volume volume;
    private GameObject _options;
    public Camera _camera;
    [SerializeField] private Slider gammaSlider;

    private void Start()
    {
        // Get the volume only once
        volume = GetComponent<Volume>();
        if (volume != null && volume.profile != null)
        {
            volume.profile.TryGet(out gamma);
        }

        // Assign slider once
        _options = GameObject.Find("=== SceneManager ===");
        if (_options != null)
        {
            gammaSlider = _options.GetComponent<Slider>();
        }
    }

    public void AdjustGamma(float value)
    {
        Debug.Log("Slider Value: " + value);

        // Null-check before accessing gamma
        if (gamma != null)
        {
            gamma.gamma.value = new Vector4(1f, 1f, 1f, value);
        }
        else
        {
            Debug.LogWarning("Gamma component is missing or not assigned.");
        }
    }
}
