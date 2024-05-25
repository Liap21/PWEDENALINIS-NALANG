using UnityEngine;
using UnityEngine.UI;

public class HealthSliderFillSaveManager : MonoBehaviour
{
    // Reference to the health slider fill image
    [SerializeField] private Image healthSliderFillImage;

    // Save the health slider fill image data to the GameData object
    public void SaveHealthSliderFill(GameData data)
    {
        // Check if the health slider fill image and its sprite are valid
        if (healthSliderFillImage != null && healthSliderFillImage.sprite != null)
        {
            // Get the sprite name
            string spriteName = healthSliderFillImage.sprite.name;

            // Save the sprite name to the GameData object
            data.healthSliderFillImage = spriteName;
        }
    }

    // Load the health slider fill image data from the GameData object and update the health slider fill image
    public void LoadHealthSliderFill(GameData data)
    {
        // Check if the sprite name is valid
        if (!string.IsNullOrEmpty(data.healthSliderFillImage))
        {
            // Load the sprite from the Resources folder using the sprite name
            Sprite fillSprite = Resources.Load<Sprite>("Health_Fill");

            // Update the health slider fill image with the loaded sprite
            if (fillSprite != null)
            {
                healthSliderFillImage.sprite = fillSprite;
            }
            else
            {
                Debug.LogError("Failed to load health slider fill sprite from Resources folder.");
            }
        }
        else
        {
            Debug.LogWarning("No health slider fill sprite name found in the GameData object.");
        }
    }
}
