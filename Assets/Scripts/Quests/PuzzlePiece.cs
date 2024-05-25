using UnityEngine;
using UnityEngine.EventSystems;

namespace Structure_Quests
{
    public class PuzzlePiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private Vector2 initialPosition;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        /// <summary>
        /// public list<RectTransform> snapPositions;
        /// </summary>
        public RectTransform snapPosition; // Assign via the Inspector
        public float snapRange = 50f; // Adjust based on your needs
        public PuzzleManager puzzleManager; // Reference to the PuzzleManager script
        public bool isSnapped = false; // Make this public for checking in PuzzleManager

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        void Start()
        {
            initialPosition = rectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isSnapped) return;

            if (canvasGroup != null) // Check if CanvasGroup component is attached
            {
                canvasGroup.alpha = 0.6f;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isSnapped) return;

            if (canvasGroup != null) // Check if CanvasGroup component is attached
            {
                // Handle touch and mouse input for dragging
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    rectTransform.anchoredPosition += touch.deltaPosition;
                }
                else
                {
                    rectTransform.anchoredPosition += eventData.delta;
                }
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (isSnapped) return;

            if (canvasGroup != null) // Check if CanvasGroup component is attached
            {
                canvasGroup.alpha = 1.0f;
                canvasGroup.blocksRaycasts = true;
                /*
                 * foreach (RectTransform 
                 * float distance = Vector2.Distance(rectTransform.anchoredPosition, snapPosition.anchoredPosition);
                 */

                float distance = Vector2.Distance(rectTransform.anchoredPosition, snapPosition.anchoredPosition);
                Debug.Log("Distance to snap position: " + distance);

                if (distance <= snapRange)
                {
                    Debug.Log("Snapping to position");
                    
                    
                    foreach(RectTransform obj_snap in snapPosition)
                    {
                        rectTransform.anchoredPosition = obj_snap.anchoredPosition;
                    }
                    

                //rectTransform.anchoredPosition = snapPosition.anchoredPosition;
                    isSnapped = true;
                    puzzleManager.CheckCompletion();
                }
                else
                {
                    Debug.Log("Returning to initial position");
                    rectTransform.anchoredPosition = initialPosition;
                }
            }
        }

        // Required to implement due to IPointerDownHandler interface
        public void OnPointerDown(PointerEventData eventData) { }
    }
}
