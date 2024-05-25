using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public string npcName;
    public string npcDialogue;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI dialogueTxt;

    public GameObject theDialoguePanel;
    public GameObject controls;

    public Image npcImage;

    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        nameTxt.text = npcName;
        dialogueTxt.text = npcDialogue;
    }

    public void OpenDialogue () {
        theDialoguePanel.SetActive (true);
        controls.SetActive (false);
    }

    public void CloseDialogue () {
        theDialoguePanel.SetActive (false);
        controls.SetActive (true);
    }
}
