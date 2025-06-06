using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class GammaChanger : MonoBehaviour
{
    private LiftGammaGain gamma;
    private Volume volume;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<LiftGammaGain>(out gamma);
    }
    public void AdjustGamma(float value)
    {
        gamma.gamma.value = new Vector4(1f, 1f, 1f, value);
    }

}