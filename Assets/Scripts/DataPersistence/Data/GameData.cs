using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Things to do:
/// Player inventory items should be saved
/// The state of the gates should be saved
/// The state of the various quests should be saved
/// The sprites need to be saved 
/// Destroyed objects should be saved
/// Health of MiniBoss should be saved
/// </summary>

[System.Serializable]
public class GameData
{
    // Data from PlayerHealth.cs
    public int maxHealth;
    public int currentHealth;
    public int deathCount;

    // ActiveInventory Slot
    public int activeSlotIndexNum;

    // Enemy Data || Health 
    public int startingHealth;

    // Player Controller
    public float playerPosX;
    public float playerPosY;

    // Health slider fill image data
    public string healthSliderFillImage;

    // Save the gameobjects of the repair quests 
    public GameObject quest_structureRuins;
    public GameObject quest_structureRepaired;

    //Inventory item sprites

    // Inventory Item's quantity
    public int inventoryItemNumber;
    public List<InventoryItem> inventoryItems;

    public void setCurrentHealth(int health)
    {
        this.currentHealth = health;
    }

    public GameData()
    {
        this.inventoryItemNumber++;
        this.maxHealth = 4;
        this.deathCount = 0;
        this.healthSliderFillImage = string.Empty; // Initialize to empty string

        //this.playerPosX;
        //this.playerPosX;
    }
}
