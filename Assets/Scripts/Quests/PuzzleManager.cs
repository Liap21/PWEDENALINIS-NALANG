using System.Collections.Generic;
using UnityEngine;

namespace Structure_Quests
{
    public class PuzzleManager : MonoBehaviour
    {
        public List<PuzzlePiece> puzzlePieces;
        public GameObject repairedStructure;
        public GameObject destroyedStructure;
        public GameObject repairPanel;
        public InfoPanelManager infoPanelManager; // Reference to the InfoPanelManager script

        public string structureTitle; // Title for the info panel
        [TextArea] public string structureInfo; // Detailed information for the info panel
        public string structureSubInfo;

        void Start()
        {
            destroyedStructure.SetActive(true);
            repairPanel.SetActive(false);
            repairedStructure.SetActive(false);
        }
        public void OpenRepairPanel()
        {
            repairPanel.SetActive(true);
        }

        public void CheckCompletion()
        {
            foreach (PuzzlePiece piece in puzzlePieces)
            {
                if (!piece.isSnapped)
                {
                    return;
                }
            }
            CompleteRepair();
        }

        public void CompleteRepair()
        {
            repairPanel.SetActive(false);
            repairedStructure.SetActive(true);
            destroyedStructure.SetActive(false);
            infoPanelManager.ShowInfo(structureTitle, structureInfo, structureSubInfo); // Show info panel
        }

        public void CloseRepairPanel()
        {
            repairPanel.SetActive(false);
        }
    }
}
