using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{

    public Transform firePosition;
    public GameObject projectile;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation);
        }




    }
}
