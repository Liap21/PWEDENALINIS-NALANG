using UnityEngine;
using UnityEngine.UI;

public class CloseRepair : MonoBehaviour
{
    [SerializeField] private GameObject repairPanel;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
        else
        {
            Debug.LogError("Close button is not assigned in the inspector.");
        }
    }

    private void ClosePanel()
    {
        if (repairPanel != null && repairPanel.activeInHierarchy)
        {
            repairPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Repair panel is not assigned in the inspector or is already inactive.");
        }
    }
}
