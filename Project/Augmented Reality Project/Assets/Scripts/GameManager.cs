using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject spawnArea;
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
        Instantiate(enemies[GetRandomEnemy()], GetRandomSpawnPos(), Quaternion.identity);
        currEnemies++;
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length);
    }

    Vector3 GetRandomSpawnPos(){
        float x = Random.Range((float)spawnArea.transform.position.x - 0.0f, (float)spawnArea.transform.position.x + 0.0f);
        float y = Random.Range((float)spawnArea.transform.position.y - 0.0f, (float)spawnArea.transform.position.y + 0.0f);
        float z = Random.Range((float)spawnArea.transform.position.z - 0.0f, (float)spawnArea.transform.position.z + 0.0f);

        return new Vector3(x,y,z);
    }
}
