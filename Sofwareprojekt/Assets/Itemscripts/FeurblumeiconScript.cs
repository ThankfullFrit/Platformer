using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeurblumeiconScript : MonoBehaviour
{
    public GameObject invenslot2;
    public GameObject Feuerblume;

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
            invenslot2.SetActive(true);
            Feuerblume.SetActive(false);
        }
    }
}
