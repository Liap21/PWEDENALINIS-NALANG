using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    public TextPopup textPopup;

    public Transform popUpTextPos; // Offset to position the popup text relative to the player

    void Start() {
        popUpTextPos = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItemToInventory();

            textPopup.StartPopup( thisItem.itemName + " x1" );
            GameObject popup = Instantiate ( textPopup.gameObject, popUpTextPos.position, popUpTextPos.rotation ) as GameObject;
            popup.GetComponent<TextPopup>().theTextPopup.color = Color.white;
            popup.transform.parent = popUpTextPos.transform;

            Destroy(gameObject);
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }

            // Display the name of the added item
            Debug.Log("Added item to inventory: " + thisItem.itemName);
        }
    }

    public void AddQuestItemToInventory(InventoryItem questItem)
    {
        if (playerInventory && questItem)
        {
            if (playerInventory.myInventory.Contains(questItem))
            {
                questItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(questItem);
                questItem.numberHeld += 1;
            }

            // Display the name of the added item
            Debug.Log("Added item to inventory: " + questItem.itemName);
        }
    }
}
