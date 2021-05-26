using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Rigidbody projectile;
    private GameObject player;
    public float speed = 0.3f;
    public float maxDistanceToAttack = 0.5f;

    public float fireRate = 2.0f;
    private float fireTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack(){
        if(fireTimer > 0.0f)
            fireTimer -= Time.deltaTime;
        else
        {
            //Create the bullet
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                            transform.position,
                                                            transform.rotation) 
                                                            as Rigidbody;

            //Make the bullet move
            Vector3 dir = player.transform.position - transform.position;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(dir.x * speed, dir.y * speed, dir.z * speed));

            fireTimer = fireRate;
        }
    }
}
