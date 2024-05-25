using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCollider : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemy;
    [SerializeField] private GameObject spawner;

    [Header("Spawn Options")]
    [SerializeField] private float spawnRadius = 5.0f;
    [SerializeField] private float spawnCooldown = 5.0f;

    private bool canSpawn = true;

    void Start()
    {
        foreach (GameObject obj_enemy in Enemy)
        {
            obj_enemy.SetActive(false);
        }
    }

    public void ActivateSpawner()
    {
        if (canSpawn)
        {
            Debug.Log("Spawning enemies...");
            StartCoroutine(SpawnEnemiesWithCooldown());
        }
        else
        {
            Debug.Log("Cannot spawn, still on cooldown.");
        }
    }

    private IEnumerator SpawnEnemiesWithCooldown()
    {
        canSpawn = false;
        SpawnEnemies();
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }

    private void SpawnEnemies()
    {
        foreach (GameObject enemy in Enemy)
        {
            if (enemy != null && !enemy.activeInHierarchy)
            {
                Vector3 spawnPosition = GetRandomPositionNearSpawner();
                enemy.transform.position = spawnPosition;
                enemy.SetActive(true);
                Debug.Log($"Enemy spawned at {spawnPosition}");
            }
        }
    }

    private Vector3 GetRandomPositionNearSpawner()
    {
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        return new Vector3(spawner.transform.position.x + randomPosition.x, spawner.transform.position.y + randomPosition.y, spawner.transform.position.z);
    }
}
