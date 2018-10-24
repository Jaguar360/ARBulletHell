using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  if (Input.GetMouseButtonDown(0))
       // {
       //     Shoot();
       // }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectile);
        bullet.transform.position = player.transform.position + player.transform.forward;
        bullet.transform.forward = player.transform.forward;
    }
}
