using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private GameObject Spawner;

    // Start is called before the first frame update
    void Start()
    {
        if (Spawner.activeInHierarchy)
        {
            Spawner.SetActive(false);
        }
        foreach (GameObject obj_enemy in Enemies) 
        {
            obj_enemy.SetActive(false);
        }
    }

    private void Update()
    {
        if (Spawner.activeInHierarchy)
        {
            foreach(GameObject obj_enemy in Enemies)
            {
                obj_enemy.SetActive(true);
            }
        }
        

    }
}
