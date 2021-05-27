using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick2 : MonoBehaviour {
    
    private Joystick joystick;
    private Rigidbody player;

    float horizontalMove = 0;
    float verticalMove = 0;

    public float moveSpeed = 5.0f;

    void Start(){

        moveSpeed /= 4;
        joystick = FindObjectOfType<Joystick>();
        player = gameObject.GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if(!GameManager.isDead){
            horizontalMove = joystick.Horizontal * moveSpeed;
            verticalMove = joystick.Vertical * moveSpeed;

            transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left")
            gameObject.transform.position = new Vector3(0.9f, transform.position.y, transform.position.z);
        
        if (other.gameObject.tag == "Right")
            gameObject.transform.position = new Vector3(-0.2f, transform.position.y, transform.position.z);

        if (other.gameObject.tag == "Top")
            gameObject.transform.position = new Vector3(transform.position.x, -0.4f, transform.position.z);

        if (other.gameObject.tag == "Bottom")
            gameObject.transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
    }
}