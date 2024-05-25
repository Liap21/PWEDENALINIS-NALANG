using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Structure_Quests
{
    public class InfoPanelManager : MonoBehaviour
    {
        public GameObject infoPanel;
        public TMP_Text titleText; // Use TMP_Text instead of Text
        public TMP_Text infoText1; // Use TMP_Text instead of Text
        public TMP_Text infoText2; // Use TMP_Text instead of Text
        public Button closeButton;

        void Start()
        {
            // Ensure the panel is hidden initially
            infoPanel.SetActive(false);
            closeButton.onClick.AddListener(HidePanel);
        }

        public void ShowInfo(string title, string info1, string info2)
        {
            titleText.text = title;
            infoText1.text = info1;
            infoText2.text = info2;
            infoPanel.SetActive(true);
        }

        private void HidePanel()
        {
            infoPanel.SetActive(false);
        }
    }
}
