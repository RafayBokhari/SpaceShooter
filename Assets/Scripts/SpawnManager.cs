using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] float respawnTime = 3f;
    [SerializeField] int enemySpawnCount;
    [SerializeField] GameController gameController;
    private bool lastEnemySpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    private void Update()
    {
        if (lastEnemySpawned && FindAnyObjectByType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.levelComplete());
        }
    }
    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
        
        lastEnemySpawned=true;
       
    }
    void SpawnEnemy()
    {
        int randomValues = Random.Range(0, enemies.Length);
        int randomXpos = Random.Range(-2, 2);
        Instantiate(enemies[randomValues],new Vector2(randomXpos,transform.position.y), Quaternion.identity);    
    }
   
}
