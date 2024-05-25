using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ContinueButton : MonoBehaviour
{
    // Path to the JSON file
    public string jsonFilePath;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the JSON file exists
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogWarning("JSON file not found: " + jsonFilePath);
            gameObject.SetActive(false); // Disable the button if the file doesn't exist
            return;
        }
    }

    public void ContinueGame()
    {
        // Read the JSON file
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON data into a GameData object
        GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

        // Load saved scene
        SceneManager.LoadScene("YourSceneName"); // Replace "YourSceneName" with the actual scene name

        // Load player health data
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.maxHealth = gameData.maxHealth;
            playerHealth.currentHealth = gameData.currentHealth;
            //playerHealth.healthSliderValue = gameData.healthSliderValue;
            playerHealth.deathCount = gameData.deathCount;
            //playerHealth.healthSliderData = gameData.healthSliderData;
        }

        // Load ActiveInventory data if it exists
        ActiveInventory activeInventory = FindObjectOfType<ActiveInventory>();
        if (activeInventory != null)
        {
            activeInventory.activeSlotIndexNum = gameData.activeSlotIndexNum;
            activeInventory.ToggleActiveHighlight(gameData.activeSlotIndexNum);
        }

        // Load other game data as needed...
    }
}
