using UnityEngine;
using UnityEngine.UI;

namespace Structure_Quests
{
    public class Structure_DialogueTrigger : MonoBehaviour
    {
        [Header ("Dialogue Contents")]
        [SerializeField] private GameObject struct_dialogueBox;
        [SerializeField] public Text struct_dialogueText;

        [Header ("Dialogue Box Buttons")]
        public Button struct_yesButton;
        public Button struct_noButton;
        public PuzzleManager puzzleManager;
        private bool isPlayerNear = false;
        private bool isDialogueOpen = false;

        [Header("Dialogue Option")]
        [SerializeField] private string repairTextDialogue;

        void Start()
        {
            struct_dialogueBox.SetActive(false);
            if (puzzleManager != null)
            {
                puzzleManager.repairPanel.SetActive(false);
            }

            struct_yesButton.onClick.AddListener(StartRepair);
            struct_noButton.onClick.AddListener(CloseDialogue);
        }

        void Update()
        {
            if (isPlayerNear && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!isDialogueOpen)
                {
                    OpenDialogue();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerNear = true;
                OpenDialogue();
                Debug.Log("Player has entered REPAIR QUEST collider");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerNear = false;
                if (isDialogueOpen)
                {
                    CloseDialogue();
                }
                Debug.Log("Player has exited REPAIR QUEST collider");
            }
        }

        void OpenDialogue()
        {
            struct_dialogueBox.SetActive(true);
            struct_dialogueText.text = repairTextDialogue;
            isDialogueOpen = true;
        }

        void StartRepair()
        {
            if (struct_dialogueBox == null)
            {
                Debug.LogError("dialogueBox is not assigned!");
            }
            if (puzzleManager == null)
            {
                Debug.LogError("puzzleManager is not assigned!");
            }
            if (puzzleManager.repairPanel == null)
            {
                Debug.LogError("repairPanel in puzzleManager is not assigned!");
            }

            struct_dialogueBox.SetActive(false);
            isDialogueOpen = false;
            puzzleManager?.OpenRepairPanel();
        }

        void CloseDialogue()
        {
            struct_dialogueBox.SetActive(false);
            isDialogueOpen = false;
        }
    }
}