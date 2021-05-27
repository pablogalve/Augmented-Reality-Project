using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public GameObject[] bulletSpawnPoints;
    public GameObject projectile;
    public float speed = 0.0f;
    public float duration = 5.0f;

    private int gunToUse = 0;

    private Button shootButton;
    private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        shootButton = GameObject.Find("ShootButton").GetComponent<Button>();
        shootButton.onClick.AddListener(OnShootButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            //Create the bullet
            GameObject instantiatedProjectile = Instantiate(projectile,
                                                            bulletSpawnPoints[gunToUse].transform.position,
                                                            bulletSpawnPoints[gunToUse].transform.rotation);

            //Make the bullet move
            Bullet bullet = instantiatedProjectile.GetComponent<Bullet>();
            bullet.SetPlayerBullet(speed, duration, new Vector3(0, 0, 1));

            //Change the gun used
            if (gunToUse < bulletSpawnPoints.Length - 1)
                gunToUse++;
            else
                gunToUse = 0;

            shoot = false;
        }
    }

    int GetRandomSpawnPos(){
        return Random.Range(0, bulletSpawnPoints.Length);
    }

    void OnShootButton()
    {
        shoot = true;
    }
}
