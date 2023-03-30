using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{

    public Transform firePosition;
    public GameObject projectile;

    public float fireRate = 1.0f;
    float nextFire = 0f;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > nextFire)   //RMB zum schieﬂen & next Fire als cooldown
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation);
            nextFire = Time.time + fireRate;
            Debug.Log("TimeTime: " + Time.time);
        }




    }
}
