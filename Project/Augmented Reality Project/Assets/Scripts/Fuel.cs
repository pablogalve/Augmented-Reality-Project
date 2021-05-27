using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    private Image fuelBarImage;
    private Vector3 fuelVec;
    public float maxFuel = 100.0f;
    public float fuel = 100.0f;
    public float healFuel = 50.0f;   

    private bool isMoving = true;  
    private Vector3 lastPos;
    public float fuelSpendSpeed = 2.0f;

    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;        
        
        GameObject imageObject = GameObject.FindGameObjectWithTag("FuelImage");

        gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();

        if (imageObject != null)
        {
            fuelBarImage = imageObject.GetComponent<Image>();
        }

        fuelVec = new Vector3(0.00f, fuel * 0.01f, 0.00f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(!GameManager.isDead){
            fuelVec.x = fuel * 0.01f;
            fuelBarImage.transform.localScale = fuelVec;

            if(fuel <= 0) 
                Die();

            checkMovement();
            if(isMoving)
                UseFuel();
        }
    }    

    void Die(){
        gameManagerScript.FinishGame();
        GameManager.isDead = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!GameManager.isDead){
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(other.gameObject); //Destroy bullet
                fuel -= Bullet.enemyDamage;
            }

            if (other.gameObject.CompareTag("Fuel"))
            {
                Destroy(other.gameObject); //Destroy fuel

                fuel += healFuel;

                if (fuel > maxFuel)
                    fuel = maxFuel;
            }

            if (other.gameObject.CompareTag("Rock"))
            {
                Destroy(other.gameObject); //Destroy rock
                fuel -= 10.0f;
            }
        }        
    }

    void checkMovement(){
        if(transform.position == lastPos)
            isMoving = false;
        else isMoving = true;
        lastPos = transform.position;
    }

    void UseFuel(){
        fuel -= fuelSpendSpeed * Time.deltaTime;
    }
}