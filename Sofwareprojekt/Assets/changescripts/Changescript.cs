using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescript : MonoBehaviour
{
    //public GameObject changedesert;
    public GameObject currentbackround;
    public GameObject newbackround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            currentbackround.SetActive(false);
            newbackround.SetActive(true);
            //changedesert.SetActive(false);
        }
    }
}