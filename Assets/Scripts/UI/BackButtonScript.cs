using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        // Get the build index of the current scene
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Use a switch statement to handle different previous scene indices
        switch (currentBuildIndex)
        {
            case 1:
                SceneManager.LoadScene(1); // Load scene with build index 1
                break;
            case 2:
                SceneManager.LoadScene(2); // Load scene with build index 2
                break;
            case 3:
                SceneManager.LoadScene(3); // Load scene with build index 3
                break;
            default:
                Debug.LogWarning("No previous scene found.");
                break;
        }
    }
}
