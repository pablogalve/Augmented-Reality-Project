using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float initialHealth = 100.0f;
    public float health = 100.0f;
    private GameManager gameManagerScript;
    public ParticleSystem explosion;
    public AudioSource audioDeath;
    public AudioSource audioImpact;

    private bool isAlreadyPlay = false;

    float explosionTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject theGameManager = GameObject.Find("GameManager");
        gameManagerScript = theGameManager.GetComponent<GameManager>();

        explosionTime = 2.0f;

        audioDeath = GameObject.Find("AudioEnemyDeath").GetComponent<AudioSource>();
        audioImpact = GameObject.Find("AudioEnemyImpact").GetComponent<AudioSource>();


        health = initialHealth + (initialHealth * gameManagerScript.round * 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if(explosion != null) {

            if (isAlreadyPlay) {

               explosionTime -= Time.deltaTime;
               Debug.Log(explosionTime.ToString());

               if (explosionTime <= 0.0f)
               {
                   gameManagerScript.currEnemies--;

                   GameManager.score += 50;
                   explosion.Stop();
           
                   Destroy(gameObject);
               }

            }

        }
        else
        {
            gameManagerScript.currEnemies--;
            GameManager.score += 50;
            Destroy(gameObject);
        }

        if (isAlreadyPlay == false && health <= 0.0f)
        {
            explosion.Play();
            audioDeath.Play();
            isAlreadyPlay = true;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //Destroy bullet
            health -= Bullet.playerDamage;
            audioImpact.Play();
        }
    }
}
