using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawnPoints;
    public int round = 1;
    public float enemiesToSpawn = 4.0f;
    private float enemiesToSpawnIncrement = 0.2f;
    public float currEnemies = 0.0f;    

    // Start is called before the first frame update
    void Start()
    {
        NextRound();
    }

    // Update is called once per frame
    void Update()
    {
        if(currEnemies <= 0)
            NextRound();
    }

    void NextRound(){        
        int maxEnemies = System.Convert.ToInt32(System.Math.Floor(enemiesToSpawn));
        for(int i = 0; i < maxEnemies; i++){
            SpawnEnemy();
        }        
        round++;    
        enemiesToSpawn *= 1.0f + enemiesToSpawnIncrement;
    }

    void SpawnEnemy(){
        Instantiate(enemies[GetRandomEnemy()], spawnPoints[GetRandomSpawnPos()].transform.position, Quaternion.identity);
        currEnemies++;
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length);
    }

    int GetRandomSpawnPos(){
        return Random.Range(0, spawnPoints.Length);
    }
}
