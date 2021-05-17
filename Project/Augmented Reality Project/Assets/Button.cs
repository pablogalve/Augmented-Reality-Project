using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Cube2;
    public bool WallOpenDoor = false;

    // Update is called once per frame
    void Update()
    {
        if (WallOpenDoor)
        {
            Cube2.transform.Translate(Vector3.up * Time.deltaTime * 5);
            SceneManager.LoadScene("3-ModelTargets", LoadSceneMode.Additive);
        }

        if(Cube2.transform.position.y > 7f)
        {
            WallOpenDoor = false;
        }
    }

    void OnMouseDown()
    {
        WallOpenDoor = true;        
    }
}
