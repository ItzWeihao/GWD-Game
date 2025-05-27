using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.Universal;
public class GammaChanger : MonoBehaviour
{
    private LiftGammaGain gamma;
    private Volume volume;
    public Slider _slider;
    public Camera _camera;
    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<LiftGammaGain>(out gamma);
        _slider = GameObject.Find("BloomSlider").GetComponent<Slider>();
    }
    public void AdjustGamma(float value)
    {
        Debug.Log("Slider Value: " + value);
        gamma.gamma.value = new Vector4(1f, 1f, 1f, value);

    }
}