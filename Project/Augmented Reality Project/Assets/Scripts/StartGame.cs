using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject[] starships; //Prefabs of the starships
    public GameObject imageTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameObject theGameManager = GameObject.Find("GameManager");
        GameManager gameManagerScript = theGameManager.GetComponent<GameManager>();
        gameManagerScript.ResetGame();
        SpawnPlayerShip();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayerShip(){

        Vector3 spawnPos = imageTarget.transform.position;
        spawnPos.y += 0.05f;

        GameObject selectedShip = Instantiate(starships[SelectShips.currentShip],
                                                        spawnPos,
                                                        transform.rotation);

        selectedShip.transform.SetParent(imageTarget.transform);

    }
}
