using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTeleport : MonoBehaviour
{
    private Teleport teleport;
    public GateTeleport NextTeleportGate;

    private void Awake()
    {
        teleport = GetComponentInParent<Teleport>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            Debug.Log("Set gate is current", gameObject);
            teleport.SetCurrentGate(this);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            Debug.Log("Set gate null", gameObject);
            teleport.SetCurrentGate(null);
        }

    }
}
