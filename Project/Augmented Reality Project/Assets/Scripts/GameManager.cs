using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public static GameObject[] spawnPoints;
    public int round = 0;
    public float enemiesToSpawn = 4.0f;
    private float enemiesToSpawnIncrement = 0.2f;
    public float currEnemies = 0.0f;

    private float waitBetweenSpawns = 5.0f;
    private float waitBetweenSpawnsTimer = 0.0f;
    private bool spawningEnemies = false;
    private int enemiesToSpawnInCurrentRound;
    private int enemiesSpawnedInCurrentRound;

    private float timer = 2.0f;
    private float roundstimer = 1.0f;
    private bool showRounds = false;

    public ParticleSystem confetti;

    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI dieText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalRoundsText;
    public TextMeshProUGUI finalScoreText;

    private float dieTextTimer = 4.0f;
    public static bool isDead = false;
    public static int score = 0;

    public AudioSource audioVictory;
    public AudioSource audioDeath;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");

        dieText.enabled = false;
        finalRoundsText.enabled = false;
        finalScoreText.enabled = false;

        NextRound();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "SCORE: " + score.ToString();

        if (!isDead){ // !isDead
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

            if(spawningEnemies)
                SpawnAllEnemies();
        }else{
            dieTextTimer -= Time.deltaTime;
            if(dieTextTimer <= 0.0f)
                SceneManager.LoadScene("MainMenu");        
        }
    }

    void NextRound(){        
        enemiesSpawnedInCurrentRound = 0;
        spawningEnemies = true;
        waitBetweenSpawnsTimer = waitBetweenSpawns;
        confetti.Play();
        round++;        
        enemiesToSpawnInCurrentRound = System.Convert.ToInt32(System.Math.Floor(enemiesToSpawn));
        currEnemies += enemiesToSpawnInCurrentRound;
        enemiesToSpawn *= 1.0f + enemiesToSpawnIncrement;
        roundsText.text = "ROUND " + (round - 1).ToString();
        showRounds = true;
        roundsText.enabled = true;

        audioVictory.Play();
    }

    void SpawnEnemy(){
        Instantiate(enemies[GetRandomEnemy()], spawnPoints[GetRandomSpawnPos()].transform.position, Quaternion.identity);        
    }

    int GetRandomEnemy(){
        return Random.Range(0, enemies.Length);
    }

    public static int GetRandomSpawnPos(){
        return Random.Range(0, spawnPoints.Length);
    }

    void SpawnAllEnemies(){
        if(waitBetweenSpawnsTimer <= 0.0f)
        {
            SpawnEnemy();
            enemiesSpawnedInCurrentRound++;
            waitBetweenSpawnsTimer = waitBetweenSpawns;
        }else{
            waitBetweenSpawnsTimer -= Time.deltaTime;
        }
        if(enemiesSpawnedInCurrentRound >= enemiesToSpawnInCurrentRound)
            spawningEnemies = false;
    }

    public void FinishGame(){
        dieText.enabled = true;
        finalScoreText.text = "TOTAL SCORE: " + score.ToString();
        finalRoundsText.text = "TOTAL ROUND: " + (round - 1).ToString();
        finalRoundsText.enabled = true;
        finalScoreText.enabled = true;
        isDead = true;

        audioDeath.Play();
    }
}
