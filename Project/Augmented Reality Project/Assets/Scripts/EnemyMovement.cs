using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;  
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed *= GetRandomSpeedMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 0.3f && Vector3.Distance(player.transform.position, transform.position) > 0.5f)
            transform.position -= Vector3.forward * speed * Time.deltaTime;
    }

    float GetRandomSpeedMultiplier(){
        return Random.Range(0.1f, 1.0f);
    }
}
