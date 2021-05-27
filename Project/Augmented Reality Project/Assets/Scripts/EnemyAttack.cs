using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public float speed = 1.8f;
    //public float maxDistanceToAttack = 0.75f;  
    private bool isMoving = true;  
    private Vector3 lastPos;

    public float fireRate = 2.0f;
    private float fireTimer = 2.0f;
    public AudioSource audioShoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioShoot = GameObject.Find("AudioEnemyDeath").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == lastPos)
            isMoving = false;
        else isMoving = true;
        lastPos = transform.position;

        Attack();
    }

    void Attack(){
    
        //float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("----------------------distance " + distanceToPlayer.ToString());

        //if(distanceToPlayer <= maxDistanceToAttack){
        if(!isMoving){
            if(fireTimer > 0.0f)
                fireTimer -= Time.deltaTime;
            else
            {
                //Create the bullet
                GameObject instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                //Make the bullet move
                Bullet bullet = instantiatedProjectile.GetComponent<Bullet>();
                Vector3 dir = player.transform.position - transform.position;
                bullet.SetEnemyBullet(speed, 3.0f, dir);
                //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(dir.x * speed, dir.y * speed, dir.z * speed));

                fireTimer = fireRate;
                audioShoot.Play();
            }
        }        
    }
}
