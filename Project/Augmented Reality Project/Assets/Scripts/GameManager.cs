using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int round = 1;
    public int enemiesLeft;
    public float currEnemies = 4.0f;
    public float enemiesIncrement = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesLeft <= 0)
            NextRound();
    }

    void NextRound(){
        int maxEnemies = System.Convert.ToInt32(System.Math.Floor(currEnemies));
        for(int i = 0; i < maxEnemies; i++)
            SpawnEnemy();
    }

    void SpawnEnemy(){
        Instantiate(enemies[GetRandomEnemy()], GetRandomSpawnPos(), Quaternion.identity);
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length - 1);
    }

    Vector3 GetRandomSpawnPos(){
        float x = Random.Range((float)transform.position.x - 1.0f, (float)transform.position.x + 1.0f);
        float y = Random.Range((float)transform.position.y - 1.0f, (float)transform.position.y + 1.0f);
        float z = Random.Range((float)transform.position.z - 1.0f, (float)transform.position.z + 1.0f);

        return new Vector3(x,y,z);
    }
}
