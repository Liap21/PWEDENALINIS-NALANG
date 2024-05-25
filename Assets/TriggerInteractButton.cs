using Unity.VisualScripting;
using UnityEngine;

public class TriggerInteractButton : MonoBehaviour
{
    public GameObject InteractButton;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractButton.SetActive(true);
            Debug.Log("Player has entered the collider");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractButton.SetActive(false);
            Debug.Log("Player has left");
        }
    }
}

/*
 * The purpose of this code is to activate the InteractButton
 * Which is used to open or activate the descriptionPanel of artifacts and 
 * structures... It makes use of a box collider 2d to sense if the player is close
 */