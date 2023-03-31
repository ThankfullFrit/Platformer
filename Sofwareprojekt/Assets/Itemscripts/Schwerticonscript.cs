using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schwerticonscript : MonoBehaviour
{
    public GameObject invenslot1;
    public GameObject Schwert;

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
            invenslot1.SetActive(true);
            Schwert.SetActive(false);
        }
    }
}