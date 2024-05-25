using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject continueButton;
    public GameObject npcConverseButton;
    public float wordSpeed;
    public bool playerIsClose;

    void Start()
    {
        if (dialogueText == null)
        {
            Debug.LogError("dialogueText is null!");
        }
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        continueButton.SetActive(false);
        npcConverseButton.SetActive(false);
    }

    void Update()
    {
        if (playerIsClose && npcConverseButton.activeInHierarchy)
        {
            if (!dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Mouse0))
            {
                OpenPanel();
                Debug.Log("Dialogue initiated");
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        continueButton.SetActive(false); // Hide the continue button when dialogue ends
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC script collision box");
            playerIsClose = true;
            npcConverseButton.SetActive(true);
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        // Show the continue button when typing is finished
        continueButton.SetActive(true);
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
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
            Debug.Log("Player exited NPC script collision box");
            playerIsClose = false;
            npcConverseButton.SetActive(false);
            zeroText();
        }
    }

    public void OpenPanel()
    {
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
    }

    public void ClosePanel()
    {
        dialoguePanel.SetActive(false);
    }
}
