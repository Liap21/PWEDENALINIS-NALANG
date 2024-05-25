using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {

    public string npcName;
    public string npcDialogue;

    public GameObject openDialogueBtn;
    public Sprite npcSprite;
    private DialogueManager theDialogueManager;

    void Start () {
        theDialogueManager = FindObjectOfType<DialogueManager> ();
    }

    void OnTriggerEnter2D (Collider2D other) {
        if ( other.gameObject.CompareTag ("Player") ) {
            theDialogueManager.npcName = npcName;
            theDialogueManager.npcDialogue = npcDialogue;
            theDialogueManager.npcImage.sprite = npcSprite;
            openDialogueBtn.SetActive (true);
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if ( other.gameObject.CompareTag ("Player") ) {
            theDialogueManager.npcName = "";
            theDialogueManager.npcDialogue = "";
            theDialogueManager.npcImage.sprite = null;
            openDialogueBtn.SetActive (false);
        }
    }
}
