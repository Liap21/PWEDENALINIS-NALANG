using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleQuest : MonoBehaviour
{

    public int counter;
    public Quest[] quests;

    

    // Update is called once per frame
    void Update()
    {
       quests[counter].gameObject.SetActive(true);
    }
}
