using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(int level)
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(level);
    }
}