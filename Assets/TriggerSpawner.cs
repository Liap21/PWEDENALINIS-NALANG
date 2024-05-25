using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnerObject;
    [SerializeField] private Collider2D spawnerTrigger;

    public bool playerIsClose;

    void Start()
    {
        spawnerObject.SetActive(false); // Ensure spawner is initially inactive
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            //spawnerTrigger.enabled = false; // Disable trigger after it's been activated
            Debug.Log("Player has entered Spawner Trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PLayer has left the enemy trigger");
            spawnerObject.SetActive(true);
            playerIsClose = false;
        }
        //Destroy(spawnerTrigger);
    }
}
