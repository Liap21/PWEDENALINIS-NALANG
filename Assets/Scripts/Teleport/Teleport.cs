using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float waitForTrastion = 3;
    [SerializeField] private GateTeleport currentGateActive;
    [SerializeField] private Transform Player;
    private Collider2D[] playerCollider;
    [Header("Fade Transtion")]
    [SerializeField] private Image screenPanel;
    [SerializeField] private float fadeSpeed = 1;
    [SerializeField] private Color color;
    [SerializeField] private bool allowTeleport;

    public Button teleButton;
    private void Awake()
    {
        allowTeleport = true;
        teleButton.gameObject.SetActive(false);
        playerCollider = Player.GetComponentsInChildren<Collider2D>();
        screenPanel.color = color;
        screenPanel.gameObject.SetActive(false);

        teleButton.onClick.AddListener(ActiveTeleport);
    }

    private void OnDestroy()
    {
        teleButton.onClick.RemoveListener(ActiveTeleport);
    }
    private void ActiveTeleport()
    {
        if (allowTeleport)
        {
            Debug.Log("get input", gameObject);
            if (currentGateActive != null)
            {
                StartTeleport(Player, currentGateActive.NextTeleportGate);
            }
        }
    }
    public void StartTeleport(Transform player, GateTeleport nextGate)
    {

        if (nextGate == null)
        {
            Debug.LogError("This gate is null");
            return;
        }
        StartCoroutine(StartTele(player, nextGate));
    }

    private IEnumerator StartTele(Transform player, GateTeleport nextGate)
    {
        screenPanel.gameObject.SetActive(true);
        yield return FadeScreen(true);

        allowTeleport = false;
        Debug.Log("get input", gameObject);

        //yield return new WaitForSeconds(waitForTrastion);
        foreach (var collider in playerCollider)
        {
            collider.enabled = false;
        }
        player.transform.position = nextGate.transform.position;

        foreach (var collider in playerCollider)
        {
            collider.enabled = true;
        }
        allowTeleport = true;
        yield return new WaitForSeconds(waitForTrastion);
        yield return FadeScreen(false);
        screenPanel.gameObject.SetActive(false);
        yield return null;
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
            screenPanel.color = color;
            yield return new WaitForEndOfFrame();
        }
    }

    public void SetCurrentGate(GateTeleport gateTeleport)
    {
        if(gateTeleport == null)
        {
            currentGateActive = null;
            teleButton.gameObject.SetActive(false);
        }
        else
        {
            teleButton.gameObject.SetActive(true); 
            currentGateActive = gateTeleport;

        }
    }
}
