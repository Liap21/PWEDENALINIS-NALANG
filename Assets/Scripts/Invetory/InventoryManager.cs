using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string itemNameTitle, string description, bool buttonActive)
    {
        itemNameText.text = itemNameTitle;
        descriptionText.text = description;
        if(buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if(playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if(playerInventory.myInventory[i].numberHeld > 0 || playerInventory.myInventory[i].itemName == "Bottle")
                {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position,  Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                ItemInventorySlot newSlot = temp.GetComponent<ItemInventorySlot>();
                if(newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        Debug.Log("Made Inventory");
        SetTextAndButton("", "", false);
    }

    public void SetupDescriptionAndButton(string newItemName, string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        itemNameText.text = newItemName;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if(currentItem) 
        {
        currentItem.Use();
        //clear all of the inventory slots
        ClearInventorySlots();
        //refill all slots with new numbers/ nawawala
        MakeInventorySlots();
        if (currentItem.numberHeld == 0)
        {
        SetTextAndButton("", "", false);
        }
        }
    }
}
