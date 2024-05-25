using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Structure_Quests
{
    using UnityEngine;
    using UnityEngine.UI;

    namespace Structure_Quests
    {
        public class OpenInfoPanel : MonoBehaviour
        {
            public GameObject informationPanel;
            public GameObject inforPanelTrigger;
            public Button closeButton;

            void Start()
            {
                // Hide the information panel initially
                informationPanel.SetActive(false);

                // Add listener to the close button
                closeButton.onClick.AddListener(ClosePanel);
            }

            private void OnCollisionEnter2D(Collision2D collision)
            {
                informationPanel.SetActive(true);
                Debug.Log("Entered Completed Quest Collider");
            }

            void OpenPanel()
            {
                // Show the information panel
                informationPanel.SetActive(true);
            }

            void ClosePanel()
            {
                // Hide the information panel
                informationPanel.SetActive(false);
            }
        }
    }

}

