using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject spawnArea;
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
        for(int i = 0; i < maxEnemies; i++){
            StartCoroutine(WaitSeconds());
            SpawnEnemy();
        }            
    }

    void SpawnEnemy(){
        Instantiate(enemies[GetRandomEnemy()], GetRandomSpawnPos(), Quaternion.identity);
        enemiesLeft++;
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length);
    }

    Vector3 GetRandomSpawnPos(){
        float x = Random.Range((float)spawnArea.transform.position.x - 0.3f, (float)spawnArea.transform.position.x + 0.3f);
        float y = Random.Range((float)spawnArea.transform.position.y - 0.3f, (float)spawnArea.transform.position.y + 0.3f);
        float z = Random.Range((float)spawnArea.transform.position.z - 0.3f, (float)spawnArea.transform.position.z + 0.3f);

        return new Vector3(x,y,z);
    }

    IEnumerator WaitSeconds()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
