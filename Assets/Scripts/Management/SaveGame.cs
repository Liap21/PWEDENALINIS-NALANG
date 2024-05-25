using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public void SaveGame()
    {
        // Save player position
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        // Save active scene index
        int activeSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("ActiveSceneIndex", activeSceneIndex);

        PlayerPrefs.Save();

        Debug.Log("Game saved.");
    }
}
