using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ItemNeedForGate
{
    public int CountNeed;
    public InventoryItem itemData;
    
    
    public void RemoveCountNeedInItem()
    {
        itemData.DecreaseAmount(CountNeed);
    }
}
public class Gate : Quest
{
    // public int counter;
    // public BoxCollider2D triggerCollider;

    // [SerializeField] private PlayerInventory PlayerInventory;
    // // [SerializeField] private string npcName;
    // // [SerializeField] public string npcDialogue;
    // // [SerializeField] private Sprite npcSprite;
    // [SerializeField] private bool isOpened;
    // public bool canOpen;
    // // [SerializeField] private GameObject openDialogueBtn;
    // public List<ItemNeedForGate> itemGateNeed;
    // public Button OkeyButton;
    // // public Collider2D gateCollider;

    // public GateSpriteSwap GateSpriteSwap;
    // private void Awake()
    // {
    //     isOpened = false;
    //     canOpen = false;
    // }
    
    // private void Test()
    // {
    //     var list = PlayerInventory.myInventory;
    //     int itemValidCounter = 0;
    //     if(itemValidCounter != 1){
    //         foreach (var itemNeedForGate in itemGateNeed)
    //         {
    //             if (!PlayerInventory.IsItemEnought(itemNeedForGate.itemData, itemNeedForGate.CountNeed))
    //             {
    //                 Debug.Log("You don't have enough " + itemNeedForGate.itemData.name + " to use.");
    //             }
    //             else
    //             {
    //                 itemValidCounter++;
    //             }
    //         }
    //         if(itemValidCounter == itemGateNeed.Count)
    //         {
    //             foreach(var item in itemGateNeed)
    //             {
    //                 item.RemoveCountNeedInItem();
    //             }
    //             canOpen = true;
    //             //questCounter = 3; 
    //             triggerCollider.enabled = false;
    //             Debug.Log("You can go the gate");
    //             // gateCollider.enabled = false;
    //             // GateSpriteSwap.Use();
    //         }
    //     }

    // }
    // private DialogueManager theDialogueManager;

    // void Start()
    // {
    //     theDialogueManager = FindObjectOfType<DialogueManager>();
    //          theQuestManager = FindObjectOfType<QuestManager> ();
    // }

    

    // protected override void ChangeInforEnter(Collider2D other){
    //     base.ChangeInforEnter(other);
    //     if(counter != 1) {
    //         if (other.gameObject.CompareTag("Player"))
    //         {
    //             if (isOpened) return;
    //             openDialogueBtn.GetComponent<Button>().onClick.AddListener(Test);
    //             OkeyButton.onClick.AddListener(OpenTheGate);
    //         }
    //     }
    // }
    // protected override void ChangeInforExit(Collider2D other){
    //     base.ChangeInforExit(other);
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         if (isOpened) return;
    //         // SetForDialogManager();
    //         openDialogueBtn.GetComponent<Button>().onClick.RemoveListener(Test);
    //         OkeyButton.onClick.RemoveListener(OpenTheGate);
    //     }
    // }
    // private void OpenTheGate(){
    //     if(canOpen){
    //         GateSpriteSwap.Use();
    //     }
    // }
}
