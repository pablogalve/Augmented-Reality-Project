using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    public GameObject fuel;
    public GameObject[] rocks;

    public float fuelTimerMin = 15.0f;
    public float fuelTimerMax = 30.0f;
    public float rockTimerMin = 5.0f;
    public float rockTimerMax = 20.0f;

    private float fuelTimer;
    private float rockTimer;

    // Start is called before the first frame update
    void Start()
    {
        fuelTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuelTimer <= 0.0f){
            fuelTimer = GetRandomTime(fuelTimerMin, fuelTimerMax);
            SpawnFuel();
        }else{
            fuelTimer -= Time.deltaTime;
        }

        if(rockTimer <= 0.0f){
            rockTimer = GetRandomTime(rockTimerMin, rockTimerMax);
            SpawnRock();
        }else{
            rockTimer -= Time.deltaTime;
        }
    }

    float GetRandomTime(float min, float max){
        return Random.Range(min, max);
    }

    void SpawnFuel(){
        Instantiate(fuel, GameManager.spawnPoints[GameManager.GetRandomSpawnPos()].transform.position, Quaternion.identity);
    }

    void SpawnRock(){
        Instantiate(rocks[GetRandomRock()], GameManager.spawnPoints[GameManager.GetRandomSpawnPos()].transform.position, Quaternion.identity);
    }

    int GetRandomRock(){
        return Random.Range(0, rocks.Length);
    }
}
