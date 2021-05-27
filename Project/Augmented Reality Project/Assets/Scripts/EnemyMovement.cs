using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;  
    public float speed = 0.05f;
    public float maxDistanceToMoveToPlayer = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed *= GetRandomSpeedMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        
        if(distanceToPlayer >= maxDistanceToMoveToPlayer)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    float GetRandomSpeedMultiplier(){
        return Random.Range(0.7f, 1.3f);
    }

    void MoveForward(){
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
}
