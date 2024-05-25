using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateTeleportType
{
    TwoWay,
    EndGame
}
public class GateTeleport : GateBase
{
    private Teleport teleport;
    public GateTeleport NextTeleportGate;
    public GateTeleportType GateTeleportType = GateTeleportType.TwoWay;
    private void Awake()
    {
        teleport = GetComponentInParent<Teleport>();
    }

    protected override void TriggerEnterCustom()
    {
        teleport.SetCurrentGate(this);
    }

    protected override void TriggerExitCustom()
    {
        teleport.SetCurrentGate(null);
    }
}
public abstract class GateBase : MonoBehaviour
{
    protected abstract void TriggerEnterCustom();
    protected abstract void TriggerExitCustom();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            Debug.Log("Set gate is current", gameObject);
            TriggerEnterCustom();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            Debug.Log("Set gate null", gameObject);
            TriggerExitCustom();
        }

    }
}