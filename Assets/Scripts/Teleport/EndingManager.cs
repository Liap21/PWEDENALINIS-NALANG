using System.Collections;

using TMPro;
using UnityEngine;


public class EndingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endingText;
    [SerializeField] private float fadeSpeed = 1;
    [SerializeField] private Color color;
    [SerializeField] private float waitBeforeDoneGame;
    [SerializeField] private GateTeleport GateTeleport;
    private void Awake()
    {
        if(GateTeleport == null)
        {
            Debug.LogWarning("Gate teleport need to asign here", gameObject);
        }
        endingText.gameObject.SetActive(false);
        GateTeleport.gameObject.SetActive(false);
    }
    public void Show()
    {
        GateTeleport.gameObject.SetActive(true);
        StartCoroutine(EndgameLoading());
    }

    private IEnumerator EndgameLoading()
    {
        endingText.gameObject.SetActive(true);
        yield return FadeScreen(true);
        yield return FadeScreen(false);
        endingText.gameObject.SetActive(false);
    }
    private IEnumerator FadeScreen(bool isShow)
    {
        while (true)
        {
            if (isShow)
            {
                color.a += Time.deltaTime * fadeSpeed;
                if (color.a >= 1) break;
            }
            else
            {
                color.a -= Time.deltaTime * fadeSpeed;
                if (color.a <= 0) break;
            }
            endingText.color = color;
            yield return new WaitForEndOfFrame();
        }
  
    }
    
}

