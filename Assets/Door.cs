using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public int counter;
    public GameObject[] quests;

    

    // Update is called once per frame
    void Update()
    {
       quests[counter].SetActive(true);
    }
}
