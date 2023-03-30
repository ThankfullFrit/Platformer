using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{

    public Transform firePosition;
    public GameObject projectile;

    public float fireRate = 1.0f;
    float nextFire = 0f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > nextFire)   //RMB zum schieﬂen & next Fire als cooldown
        {
            anim.SetBool("IsFiring", true);
            Instantiate(projectile, firePosition.position, firePosition.rotation);
            nextFire = Time.time + fireRate;
            Debug.Log("TimeTime: " + Time.time);


        }


    }
}
