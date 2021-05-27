using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public float speed = 1.8f;
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
            GameObject instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

            //Make the bullet move
            Bullet bullet = instantiatedProjectile.GetComponent<Bullet>();
            bullet.SetEnemyBullet(speed, 3.0f, new Vector3(0, 0, -1));
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(dir.x * speed, dir.y * speed, dir.z * speed));

            fireTimer = fireRate;
        }
    }
}
