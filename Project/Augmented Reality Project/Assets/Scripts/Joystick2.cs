using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick2 : MonoBehaviour {
    
    public Joystick joystick;

    float horizontalMove = 0;
    float verticalMove = 0;

    public float moveSpeed = 5.0f;

    void Start(){

        moveSpeed /= 4;
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {

        horizontalMove = joystick.Horizontal * moveSpeed;
        verticalMove = joystick.Vertical * moveSpeed;

        transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime;

    }
    

}