using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // allows an asset to be saved to a file
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]

public class PlayerInventory : ScriptableObject
{
   public List<InventoryItem> myInventory = new List<InventoryItem>();

   public bool IsItemEnought(InventoryItem itemNeedToCheck, int numberNeed)
    {
        if(numberNeed <= 0) return false;   
        foreach (var item in myInventory)
        {
            if(item == itemNeedToCheck)
            {
                if(item.numberHeld - numberNeed >= 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
