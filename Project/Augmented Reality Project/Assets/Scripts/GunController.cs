using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject[] bulletSpawnPoints;
    public Rigidbody projectile;
    public float speed = 0.3f;

    private int gunToUse = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Create the bullet
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                            bulletSpawnPoints[gunToUse].transform.position,
                                                            bulletSpawnPoints[gunToUse].transform.rotation) 
                                                            as Rigidbody;

            //Make the bullet move
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            //Change the gun used
            if(gunToUse < bulletSpawnPoints.Length - 1)
                gunToUse++;
            else
                gunToUse = 0;
        }
    }

    int GetRandomSpawnPos(){
        return Random.Range(0, bulletSpawnPoints.Length);
    }
}
