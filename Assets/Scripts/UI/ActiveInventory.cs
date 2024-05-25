using System.Collections;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>, IDataPersistence
{
    public int activeSlotIndexNum = 0;

    private PlayerControls playerControls;

    private GameObject currentWeaponInstance;

    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
    }
    
    public void LoadData(GameData data)
    {
        this.activeSlotIndexNum = data.activeSlotIndexNum;
        ToggleActiveHighlight(activeSlotIndexNum);
    }

    public void SaveData(ref GameData data)
    {
        data.activeSlotIndexNum = this.activeSlotIndexNum;
    }

    private void Start()
    {
        playerControls.Inventory.Inventory.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    public void EquipStartingWeapon()
    {
        ToggleActiveHighlight(0);
    }

    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighlight(numValue - 1);
    }

    public void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;

        foreach (Transform inventorySlot in transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        Transform activeSlot = transform.GetChild(indexNum);
        if (activeSlot == null)
        {
            Debug.LogError("Active slot not found!");
            return;
        }

        activeSlot.GetChild(0).gameObject.SetActive(true);

        // Pass the transform of the active slot to ChangeActiveWeapon method
        ChangeActiveWeapon(activeSlot);
    }

    private void ChangeActiveWeapon(Transform activeSlot)
    {
        if (activeSlot == null)
        {
            Debug.LogError("Active slot is null!");
            return;
        }

        // Destroy the current weapon instance if it exists
        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
        }

        InventorySlot inventorySlot = activeSlot.GetComponent<InventorySlot>();
        if (inventorySlot == null)
        {
            Debug.LogError("Inventory slot component not found on active slot!");
            return;
        }

        WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
        if (weaponInfo == null)
        {
            Debug.LogError("Weapon info not found on active slot!");
            return;
        }

        GameObject weaponToSpawn = weaponInfo.weaponPrefab;

        // Instantiate the new weapon and store the reference to it
        currentWeaponInstance = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform);

        ActiveWeapon.Instance.NewWeapon(currentWeaponInstance.GetComponent<MonoBehaviour>());
    }
}
