using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectShips : MonoBehaviour
{
    public GameObject[] starships;
    public Button rightArrow;
    public Button leftArrow;
    public static int currentShip = 0;
    private bool change = false;

    // Start is called before the first frame update
    void Start()
    {
        
        rightArrow = rightArrow.GetComponent<Button>();
        leftArrow = leftArrow.GetComponent<Button>();

        for(int i = 0; i < starships.Length; i++){
            starships[i].SetActive(false);
        }
        
        rightArrow.onClick.AddListener(OnClickRight);
        leftArrow.onClick.AddListener(OnClickLeft);
        change = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            starships[currentShip].SetActive(true);            
            change = false;
        }
    }

    void OnClickRight()
    {
        Debug.Log(currentShip.ToString());

        if (currentShip > 0)
        {
            starships[currentShip].SetActive(false);
            currentShip -= 1;
            change = true;            
        }
    }

    void OnClickLeft()
    {
        Debug.Log(currentShip.ToString());

        if (currentShip < 4)
        {
            starships[currentShip].SetActive(false);
            currentShip += 1;
            change = true;            
        }
    }
}
