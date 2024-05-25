using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInventorySlot : MonoBehaviour //IDataPersistence
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemImage; 

    [Header("Variables from item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    void Update(){
        itemNumberText.text = "" + thisItem.numberHeld;
    }

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    /*
    // Saving and Loading below - Michael

    // This will save the Item number to its assigned reference in GameData.cs
    public void SaveData(ref GameData gameData)
    {
        //number of items in the invenotry 
        this.thisItem.numberHeld = gameData.inventoryItemNumber;
    }

    // LoadData will get the saved data from GameData.cs
    public void LoadData(GameData gameData)
    {
        //number of items in the invenotry 
        gameData.inventoryItemNumber = this.thisItem.numberHeld;
    }
    */

    public void ClickedOn()
    {
        if(thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemName, thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
}
