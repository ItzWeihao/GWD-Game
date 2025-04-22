using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;  // Reference to the Light component
    public float minIntensity = 0.5f;  // Minimum light intensity
    public float maxIntensity = 1.5f;  // Maximum light intensity
    public float flickerInterval = 0.1f;  // Speed of the flicker

    private float timeSinceLastFlicker;
    private bool isFlickering = false;
    private float targetIntensity;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();  // Get Light component if not assigned in the Inspector
        }

        targetIntensity = lightSource.intensity;  // Start with the current intensity
    }

    void Update()
    {
        timeSinceLastFlicker += Time.deltaTime;

        if (timeSinceLastFlicker >= flickerInterval)
        {
            timeSinceLastFlicker = 0f;  // Reset the flicker timer

            // Randomly change the intensity
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }

    // Method to start flickering
    public void StartFlickering()
    {
        lightSource.enabled = true;
        lightSource.color = Color.red;
        isFlickering = true;
    }

    // Method to stop flickering
    public void StopFlickering()
    {
        lightSource.enabled = false;
        isFlickering = false;
        lightSource.intensity = targetIntensity;  // Reset to the initial intensity
    }
}
