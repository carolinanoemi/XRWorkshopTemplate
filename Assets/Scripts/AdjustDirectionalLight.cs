using UnityEngine;

// This script allows the user to adjust the intensity of a directional light using the Up and Down arrow keys.

public class AdjustDirectionalLight : MonoBehaviour
{
   
    [Header("Directional Light Settings")]
    public Light directionalLight;

    [Tooltip ("How much the light intensity will increase or decrease with each adjustment")]
    public float intensityStep = 0.4f;

    [Tooltip("Minimum intensity limit for the directional light")]
    public float minIntensity = 0f;

    [Tooltip("Maximum intensity limit for the directional light")]
    public float maxIntensity = 5f;

    void Update()
    {
        // Increase intensity with Up Arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AdjustIntensity(intensityStep);
        }
        // Decrease intensity with Down Arrow
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AdjustIntensity(-intensityStep);
        }
    }

    // Function to adjust the intensity of the directional light
    public void AdjustIntensity(float adjustment)
    {
        //if directionalLight is assigned, adjust its intensity
        if (directionalLight != null)
        {
            directionalLight.intensity = Mathf.Clamp(directionalLight.intensity + adjustment, minIntensity, maxIntensity);
        }
        else
        {
            Debug.LogWarning("Directional Light is not assigned.");
        }
    }

}
