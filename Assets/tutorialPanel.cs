// Gawa ni Michael to heheheh
using UnityEngine;
using UnityEngine.UI;

namespace tutorialGameObjects
{
    public class tutorialPanel : MonoBehaviour
    {
        [Header("Tutorial GameObjects")]
        [SerializeField] private GameObject tutorialPane; // Main Panel
        [SerializeField] private GameObject otherTutorialPanels;

        [Header("Buttons")]
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private Button closeButton;

        void Start()
        {
            // Check if the main panel is not active in the hierarchy and make it active
            if (!tutorialPane.activeInHierarchy)
            {
                tutorialPane.SetActive(true);
            }

            // Set up button listeners
            yesButton.onClick.AddListener(AcceptTutorial);
            noButton.onClick.AddListener(DeclineTutorial);
            closeButton.onClick.AddListener(closePanel);
        }

        private void DeclineTutorial()
        {
            // Hide the tutorial panel if the user declines the tutorial
            tutorialPane.SetActive(false);
        }

        private void AcceptTutorial()
        {
            // Show other tutorial panels and hide the main panel
            otherTutorialPanels.SetActive(true);    
        }

        private void closePanel()
        { 
            otherTutorialPanels.SetActive(false);
            tutorialPane.SetActive(false);
        }
    }
}
