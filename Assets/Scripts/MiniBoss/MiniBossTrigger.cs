using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Goal of this script is to spawn the boss in the arena
// NOTE: Script is still in progress, wala ako sinundan na tutorial ah - Michael
// Message me if there are any questions 

public class SlimeKing : MonoBehaviour
{
    [SerializeField] public GameObject MiniBoss;
    [SerializeField] public GameObject Trigger;
    [SerializeField] public GameObject MiniBoss_HealthBar;
    [SerializeField] public GameObject MiniBoss_Boundary;

    public bool playerIsClose;

    private void OnTriggerEnter2D(Collider2D MBTrigger)
    {
        if (MBTrigger.CompareTag("Player"))
        {
            playerIsClose = true;
            triggerBoss();
        }
    }

    private void OnTriggerExit2D(Collider2D MBTrigger)
    {
        if (MBTrigger.CompareTag("Player"))
        {
            playerIsClose = false;
            Destroy(Trigger);
        }
    }

    public void triggerBoss()
    {
            MiniBoss.SetActive(true);
            MiniBoss_HealthBar.SetActive(true);
            MiniBoss_Boundary.SetActive(true);
    }
}
