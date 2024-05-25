using UnityEngine.UI;
using UnityEngine;

public class openStructureBox : MonoBehaviour
{
    [Header ("Repair Structure dialogue Opener")]
    [SerializeField] GameObject buildButton;
    [SerializeField] GameObject structureBox;

    private bool playerIsClose;

    private void Start()
    {
        buildButton.SetActive(false);
        structureBox.SetActive(false); 
    }

    void Update()
    {
        if (playerIsClose && buildButton.activeInHierarchy)
        {
            if (!structureBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Mouse0))
            {
                OpenPanel();
                Debug.Log("Dialogue initiated");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D structure)
    {
        if (structure.CompareTag("Player"))
        {
            Debug.Log("Player has entered structure collider!");
            playerIsClose = true;
            buildButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D structure)
    {
        Debug.Log("Player has eft the structure collider!");
        playerIsClose = false;
        buildButton.SetActive(false);
    }

    private void OpenPanel()
    {
        structureBox.SetActive(true);
    }

    private void ClosePanel()
    {
        structureBox.SetActive(false);
    }
}
