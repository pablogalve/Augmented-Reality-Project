using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public static GameObject[] spawnPoints;
    public int round = 0;
    public float enemiesToSpawn = 4.0f;
    private float enemiesToSpawnIncrement = 0.2f;
    public float currEnemies = 0.0f;

    private float timer = 2.0f;
    private float roundstimer = 1.0f;
    private bool showRounds = false;

    public ParticleSystem confetti;
    public TextMeshProUGUI roundsText;

    // Start is called before the first frame update
    void Start()
    {
        confetti = confetti.GetComponent<ParticleSystem>();
        roundsText = roundsText.GetComponent<TextMeshProUGUI>();
        
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");

        NextRound();
    }

    // Update is called once per frame
    void Update()
    {
        if(currEnemies <= 0)
            NextRound();        

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Pressing Space");
            NextRound();
        }

        if (confetti.isPlaying) 
        {
            timer -= Time.deltaTime;
            
            if (timer <= 0)
            {
                confetti.Stop();
                timer = 2.0f;
            }
        }

        if (showRounds) 
        {
            roundstimer -= Time.deltaTime;
            if(roundstimer <= 0) 
            {
                roundsText.enabled = false;
                showRounds = false;
                roundstimer = 1.0f;
            }
        }
    }

    void NextRound(){        
        int maxEnemies = System.Convert.ToInt32(System.Math.Floor(enemiesToSpawn));
        for(int i = 0; i < maxEnemies; i++){
            SpawnEnemy();
        }
        confetti.Play();
        round++;
        enemiesToSpawn *= 1.0f + enemiesToSpawnIncrement;
        roundsText.text = "ROUND " + (round - 1).ToString();
        showRounds = true;
        roundsText.enabled = true;
    }

    void SpawnEnemy(){
        Instantiate(enemies[GetRandomEnemy()], spawnPoints[GetRandomSpawnPos()].transform.position, Quaternion.identity);
        currEnemies++;
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length);
    }

    public static int GetRandomSpawnPos(){
        return Random.Range(0, spawnPoints.Length);
    }
}
