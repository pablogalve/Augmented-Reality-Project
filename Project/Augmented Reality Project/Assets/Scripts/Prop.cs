using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0.0f, 0.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
