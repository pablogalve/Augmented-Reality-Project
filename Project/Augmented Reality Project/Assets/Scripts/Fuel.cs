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

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        
        GameObject imageObject = GameObject.FindGameObjectWithTag("FuelImage");
 
        if(imageObject != null)
        {
            fuelBarImage = imageObject.GetComponent<Image>();
        }

        fuelVec = new Vector3(0.00f, fuel * 0.01f, 0.00f);
    }

    // Update is called once per frame
    void Update()
    {       
        fuelVec.x = fuel * 0.01f;
        fuelBarImage.transform.localScale = fuelVec;
    }    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAA");
            //Destroy(other.gameObject); //Destroy bullet
            //fuel -= Bullet.enemyDamage;
        }
        
        if (other.gameObject.CompareTag("Fuel"))
        {
            Destroy(other.gameObject); //Destroy fuel

            fuel += healFuel;

            if (fuel > maxFuel)
                fuel = maxFuel;

        }
    }
}