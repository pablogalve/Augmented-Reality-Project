using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float initialHealth = 100.0f;
    public float health = 100.0f;
    private GameManager gameManagerScript;
    public ParticleSystem explosion;


    float explosionTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject theGameManager = GameObject.Find("GameManager");
        gameManagerScript = theGameManager.GetComponent<GameManager>();

        explosion = explosion.GetComponent<ParticleSystem>();
        explosionTime = explosion.main.duration;

        health = initialHealth + (initialHealth * gameManagerScript.round * 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (explosion.isPlaying)
        {
            explosionTime -= Time.deltaTime;
            
            if (explosionTime <= 0)
            {
                Destroy(gameObject);
                gameManagerScript.currEnemies--;

                explosion.Stop();
                explosionTime = 2.0f;
            }
        }

        if (health <= 0.0f)
        {
            explosion.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //Destroy bullet
            health -= Bullet.playerDamage;
        }*/
    }
}
