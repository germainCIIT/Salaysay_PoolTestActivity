using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawnpoint;
    [SerializeField] private GameObject Enemyprefab;
    
    private float TimeToSpawn = 1.3f;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    void Start()
    {
        Spawnpoint = GameObject.FindGameObjectsWithTag("Spawnpoint");
        InitializeEnemyPool();
        StartCoroutine(SpawnEnemies());
    }

    void InitializeEnemyPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(Enemyprefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int RandomIndex = Random.Range(0, Spawnpoint.Length);
            
            Vector3 SpawnLocation = Spawnpoint[RandomIndex].transform.position;
            
            SpawnEnemyTgt(SpawnLocation);
            yield return new WaitForSeconds(TimeToSpawn);
        }
    }

    void SpawnEnemyTgt(Vector3 enemy)
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemyObject = enemyPool.Dequeue();
            enemyObject.transform.position = enemy;
            enemyObject.SetActive(true);
        }
        else
        {
            GameObject enemyObject = Instantiate(Enemyprefab);
            enemyObject.transform.position = enemy;
            enemyPool.Enqueue(enemyObject);
        }
    }
}
