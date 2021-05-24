using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float initialHealth = 100.0f;
    public float health = 100.0f;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject theGameManager = GameObject.Find("GameManager");
        gameManagerScript = theGameManager.GetComponent<GameManager>();
        health = initialHealth + (initialHealth * gameManagerScript.round * 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("------------------------------------------HEALTH: " + health);

        if(health <= 0.0f)
        {            
            Destroy(gameObject);
            gameManagerScript.currEnemies--;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); //Destroy bullet
            health -= Bullet.damage;
        }
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }
}
