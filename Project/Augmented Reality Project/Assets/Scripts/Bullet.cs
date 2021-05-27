using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float playerDamage = 50.0f;
    public static float enemyDamage = 10.0f;

    private Vector3 direction;
    private float speed;
    private float durationTimer;

    //Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(durationTimer >= 0.0f)
        {
            durationTimer -= Time.deltaTime;
            transform.position += direction * speed * Time.deltaTime;
            //m_Rigidbody.MovePosition(transform.position + direction * Time.deltaTime * speed);
        }else{
            Destroy(gameObject);
        }
    }

    public void SetPlayerBullet(float _speed, float _duration, Vector3 _direction){
        direction = _direction;
        speed = _speed;
        durationTimer = _duration;
    }

    public void SetEnemyBullet(float _speed, float _duration, Vector3 _direction)
    {
        direction = _direction;
        speed = _speed;
        durationTimer = _duration;
    }
}
