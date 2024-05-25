using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Structures : MonoBehaviour
{
    public GameObject descriptionPanel;
    public Text descriptionText;
    public string[] description;
    private int index;

    public GameObject InteractButton;
    public GameObject continueButton;
    public GameObject StructureCollider; // The separate collider to trigger interaction
    public float wordSpeed;
    public bool playerIsClose;

    void Start()
    {
        if (descriptionText == null)
        {
            Debug.LogError("descriptionText is null!");
        }
        descriptionPanel.SetActive(false);
        InteractButton.SetActive(false);
        continueButton.SetActive(false);
    }

    void Update()
    {
        if (playerIsClose && InteractButton.activeInHierarchy)
        {
            if (!descriptionPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Mouse0))
            {
                OpenPanel(); 
                StartCoroutine(Typing()); 
                Debug.Log("Description initiated");
            }
        }
    }

    public void zeroText()
    {
        descriptionText.text = "";
        index = 0;
        descriptionPanel.SetActive(false);
        InteractButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered StructureCollider's collision box");
            playerIsClose = true;
            InteractButton.SetActive(true); 
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in description[index].ToCharArray())
        {
            descriptionText.text += letter;
            yield return new WaitForSeconds(wordSpeed); 
        }
        continueButton.SetActive(true);
    }

    public void NextLine()
    {
        if (index < description.Length - 1)
        {
            index++;
            descriptionText.text = ""; 
            StartCoroutine(Typing()); 
        }
        else
        {
            zeroText(); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            InteractButton.SetActive(false); 
            zeroText(); 
        }
    }

    public void OpenPanel()
    {
        descriptionPanel.SetActive(true); 
    }

    public void ClosePanel()
    {
        descriptionPanel.SetActive(false); 
    }
}
