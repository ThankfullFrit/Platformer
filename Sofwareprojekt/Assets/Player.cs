using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;


    private Animator anim;
    private Vector3 rotation;

    public GameObject panel;
    public GameObject kamera;
    public GameObject planetele;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        respawnPoint = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");

        if (richtung != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        if (richtung < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }
        if (richtung > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }
        if (isgrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }
        kamera.transform.position = new Vector3(transform.position.x, 0, -10);


        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        
    }

    


    public void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "ground")
        {
            isgrounded = true;
        }
        if (Collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
        

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }

        
        
        // while(other.gameObject.tag == "Teleporter")
        {
            //Destroy(gameObject);
           // planetele.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (Collision.gameObject.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}