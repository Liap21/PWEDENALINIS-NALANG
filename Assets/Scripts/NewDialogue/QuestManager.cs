using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour {

    public int questCounter;

    public string questGiverName;
    public Image npcImageQuestComplete;
    public string questGiverDialogueGive;
    public string questGiverDialogueAccept;
    public string questGiverDialogueDecline;
    public string questGiverDialogueCheck;
    public string questGiverDialogueThankyou;
    public string questGiverDialogueDone;

    public string itemNameNeed;
    public int amtOfItemNeeded;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI dialogueTxt;

    public Quest thisQuest;
    public GameObject theDialoguePanel;
    public GameObject controls;
    public GameObject YN;
    public GameObject okayBtn;

    public Sprite npcSpriteQuestComplete;

    public bool hasReward;
    private InventoryItem thisItem;
    public InventoryItem rewardItem;
    private InventoryManager theInventoryManager;
    private PhysicalInventoryItem physicalInventoryItem;
    
    // Start is called before the first frame update
    void Start () {
        theInventoryManager = FindObjectOfType<InventoryManager> ();
        physicalInventoryItem = FindObjectOfType<PhysicalInventoryItem>();
        PlayerPrefs.SetInt("Quest_" + thisQuest.questGiverName, thisQuest.questCounter);
    }

    // Update is called once per frame
    void Update () {
        nameTxt.text = questGiverName;
        
    }

    public void OpenDialogue () {

        if (questCounter == 0) {
            dialogueTxt.text = questGiverDialogueGive;
        } else if (questCounter == 1) {
            dialogueTxt.text = questGiverDialogueCheck;
        } else {
            dialogueTxt.text = questGiverDialogueDone;
        }

        if (questCounter == 2 || questCounter == 3) {
            okayBtn.SetActive(true);
            YN.SetActive(false);
            thisQuest.npcSpriteRenderer.sprite = npcSpriteQuestComplete;
            npcImageQuestComplete.sprite = thisQuest.npcImageQuestComplete;
        } else {
            YN.SetActive(true);
            okayBtn.SetActive(false);
        }

        theDialoguePanel.SetActive(true);
        controls.SetActive(false);
    }

    public void Yes () {
        if (questCounter == 0) {
            dialogueTxt.text = questGiverDialogueAccept;
            questCounter = 1;
            thisQuest.questCounter = 1; 
            YN.SetActive(false);
            okayBtn.SetActive(true);
        } else if (questCounter == 1) {

            //firstItemQuest = false;

            for (int i = 0; i < theInventoryManager.playerInventory.myInventory.Count; i++) {
                if (theInventoryManager.playerInventory.myInventory[i].itemName == itemNameNeed) {
                    thisItem = theInventoryManager.playerInventory.myInventory[i];
                    break;
                    //firstItemQuest = true
                }
            }

            if (theInventoryManager.playerInventory.myInventory.Contains(thisItem) && thisItem.numberHeld >= amtOfItemNeeded) {
                thisItem.numberHeld -= amtOfItemNeeded;
                if(hasReward)
                {
                    physicalInventoryItem.AddQuestItemToInventory(rewardItem);
                }
                dialogueTxt.text = questGiverDialogueThankyou;
                thisQuest.npcSpriteRenderer.sprite = npcSpriteQuestComplete; // Change the sprite
                npcImageQuestComplete.sprite = thisQuest.npcImageQuestComplete;
                questCounter = 2;
                
                YN.SetActive(false);
                okayBtn.SetActive(true);
            } else {
                dialogueTxt.text = "Sorry, but you still don't have the item/element that I needed or you still don't have much amount of the item that I needed.";
                YN.SetActive(false);
                okayBtn.SetActive(true);
            }
        }
    }

    public void No () {
        if (questCounter == 0) {
            dialogueTxt.text = questGiverDialogueDecline;
            YN.SetActive(false);
            okayBtn.SetActive(true);
        } else if (questCounter == 1) {
            dialogueTxt.text = "Its fine. Just remember that I need " + amtOfItemNeeded + " " + itemNameNeed;
            YN.SetActive(false);
            okayBtn.SetActive(true);
        }
    }

    public void Okay () {
        if (questCounter == 0) {
            theDialoguePanel.SetActive(false);
            controls.SetActive(true);
        } else if (questCounter == 2) {
            thisQuest.questCounter = 3;
            if(thisQuest.multipleQuest)
                {  
                    thisQuest.theMultipleQuest.counter++;
                    thisQuest.gameObject.SetActive(false);
                }

            if(thisQuest.isDoor)
                {  
                    thisQuest.theDoor.counter++;
                    thisQuest.gameObject.SetActive(false);
                }
                
            theDialoguePanel.SetActive(false);
            controls.SetActive(true);
        } else {
            theDialoguePanel.SetActive(false);
            controls.SetActive(true);
        }
    }

    public void CloseDialogue () {
        theDialoguePanel.SetActive(false);
        controls.SetActive(true);
    }



}
