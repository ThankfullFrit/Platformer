using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schuhesiconcript : MonoBehaviour
{
    public GameObject invenslot3;
    public GameObject Schuhe;

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
            invenslot3.SetActive(true);
            Schuhe.SetActive(false);
        }
    }
}

