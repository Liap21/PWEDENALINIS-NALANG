using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Quest : MonoBehaviour {
 
    public int questCounter;
 
    public string questGiverName;
    public Sprite npcImageQuestComplete;
    public string questGiverDialogueGive;
    public string questGiverDialogueAccept;
    public string questGiverDialogueDecline;
    public string questGiverDialogueCheck;
    public string questGiverDialogueThankyou;
    public string questGiverDialogueDone;
    public bool hasReward;
    public InventoryItem rewardItem;
 
    public string itemNameNeed;
    public int amtOfItemNeeded;
 
    public GameObject openDialogueBtn;
    private QuestManager theQuestManager;
 
    public Sprite npcSpriteComplete;
    public SpriteRenderer npcSpriteRenderer;
 
    public bool multipleQuest;
    public MultipleQuest theMultipleQuest;
    public bool isDoor;
    public Door theDoor;
 
    void Start () {
        // PlayerPrefs Int questCounter "Quest" + questGiverName
        // if == 2 or == 3 questCounter
 
        questCounter = PlayerPrefs.GetInt("Quest_" + questGiverName);
 
        if ( questCounter == 2 || questCounter == 3 ) 
            {
                npcSpriteRenderer.sprite = npcSpriteComplete;
            }              
 
        if(multipleQuest)
        {
            theMultipleQuest = GetComponentInParent<MultipleQuest>();
        }

          if(isDoor)
        {
            theDoor = GetComponentInParent<Door>();
        }
 
        theQuestManager = FindObjectOfType<QuestManager> ();
        npcSpriteRenderer = GetComponent<SpriteRenderer>();
 
    }
 
    void OnTriggerEnter2D (Collider2D other) {
        if ( other.gameObject.CompareTag ("Player") ) {
            theQuestManager.thisQuest = this.gameObject.GetComponent<Quest> ();
            theQuestManager.questCounter = questCounter;
            theQuestManager.questGiverName = questGiverName;
            theQuestManager.itemNameNeed = itemNameNeed;
            theQuestManager.amtOfItemNeeded = amtOfItemNeeded;
            theQuestManager.questGiverDialogueAccept = questGiverDialogueAccept;
            theQuestManager.questGiverDialogueDecline = questGiverDialogueDecline;
            theQuestManager.questGiverDialogueGive = questGiverDialogueGive;
            theQuestManager.questGiverDialogueCheck = questGiverDialogueCheck;
            theQuestManager.questGiverDialogueThankyou = questGiverDialogueThankyou;
            theQuestManager.questGiverDialogueDone = questGiverDialogueDone;
            theQuestManager.npcSpriteQuestComplete = npcSpriteComplete;
            if(hasReward) 
            {
                theQuestManager.rewardItem = rewardItem;
                theQuestManager.hasReward = hasReward;
            }
            else
            {
                theQuestManager.rewardItem = null;
            }
            openDialogueBtn.SetActive (true);
        }
    }
 
    void OnTriggerExit2D (Collider2D other) {
        if ( other.gameObject.CompareTag ("Player") ) {
            theQuestManager.thisQuest = null;
            theQuestManager.questCounter = 0;
            theQuestManager.questGiverName = "";
            theQuestManager.questGiverDialogueAccept = "";
            theQuestManager.questGiverDialogueDecline = "";
            theQuestManager.questGiverDialogueGive = "";
            theQuestManager.questGiverDialogueCheck = "";
            theQuestManager.questGiverDialogueThankyou = "";
            theQuestManager.questGiverDialogueDone = "";
            theQuestManager.npcSpriteQuestComplete = null;    
            if(hasReward) 
            {
                theQuestManager.rewardItem = null;
                theQuestManager.hasReward = false;
            }
            else
            {
                theQuestManager.rewardItem = null;
            }
            openDialogueBtn.SetActive (false);
        }
    }
    public void SetQuestCounter(int counter)
    {
        questCounter = counter;
        PlayerPrefs.SetInt("Quest_" + questGiverName, questCounter);
        PlayerPrefs.Save();
    }
}