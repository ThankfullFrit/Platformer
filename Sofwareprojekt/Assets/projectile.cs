using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float projectileSpeed;
    private new Rigidbody2D rigidbody;
    public GameObject impact;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            
        }
        //Instantiate(impact, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }
}
