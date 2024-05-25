using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace tutorialGameObjects
{
    public class TutorialInformationPanel : MonoBehaviour
    {
        [Header("Visuals")]
        [SerializeField] private GameObject otherPanels;
        /// [SerializeField] private GameObject pointer;


        [Header("Buttons")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button forwardButton;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI headerText;
        [SerializeField] private TextMeshProUGUI bodyText;

        [Header("Tutorial Steps")]
        [SerializeField] private List<TutorialStep> tutorialSteps;

        private int currentStepIndex = 0;

        private void Start()
        {
            if (otherPanels.activeInHierarchy)
            {
                otherPanels.SetActive(false);
            }

            backButton.onClick.AddListener(Back);
            forwardButton.onClick.AddListener(Forward);

            UpdateTutorialStep();
        }

        private void UpdateTutorialStep()
        {
            if (tutorialSteps != null && tutorialSteps.Count > 0)
            {
                // Update header and body text
                headerText.text = tutorialSteps[currentStepIndex].header;
                bodyText.text = tutorialSteps[currentStepIndex].body;

                // Update pointer position and rotation
               // pointer.transform.position = tutorialSteps[currentStepIndex].pointerPosition;
               // pointer.transform.rotation = Quaternion.Euler(0, 0, tutorialSteps[currentStepIndex].pointerRotationZ);

                // Manage back button visibility
                backButton.gameObject.SetActive(currentStepIndex > 0);

                // Manage forward button visibility
                forwardButton.gameObject.SetActive(currentStepIndex < tutorialSteps.Count - 1);
            }
        }

        private void Back()
        {
            if (currentStepIndex > 0)
            {
                currentStepIndex--;
                UpdateTutorialStep();
            }
        }

        private void Forward()
        {
            if (currentStepIndex < tutorialSteps.Count - 1)
            {
                currentStepIndex++;
                UpdateTutorialStep();
            }
        }
    }
}
