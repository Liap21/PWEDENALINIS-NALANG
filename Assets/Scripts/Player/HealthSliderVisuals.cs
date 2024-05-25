using UnityEngine;
using UnityEngine.UI;

public class HealthSliderVisuals : MonoBehaviour
{
    private Slider healthSlider;

    private void Start()
    {
        // Find the health slider component
        healthSlider = GetComponentInChildren<Slider>();

        if (healthSlider == null)
        {
            Debug.LogError("Health slider not found.");
            return;
        }

        // Subscribe to events or perform any initialization here
    }

    public void UpdateHealthVisuals(float currentValue, float maxValue)
    {
        // Update the health slider visuals based on current and max values
        healthSlider.value = currentValue;
        healthSlider.maxValue = maxValue;
    }
}
