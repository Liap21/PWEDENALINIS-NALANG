using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        // Create or ensure the ActiveInventory instance exists
        if (ActiveInventory.Instance == null)
        {
            GameObject activeInventoryObject = new GameObject("ActiveInventory");
            activeInventoryObject.AddComponent<ActiveInventory>();
        }

        // Make sure this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);
    }
}
