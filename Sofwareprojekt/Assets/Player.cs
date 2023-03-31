using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;
    private int jumpCount = 0; // Variable zum Zählen der Sprünge

    private Animator anim;
    private Vector3 rotation;

    public GameObject panel;
    public GameObject kamera;
    public GameObject planetele;

    public Vector3 respawnPoint;
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

        if (Input.GetKeyDown(KeyCode.Space) && (isgrounded || jumpCount < 2)) // Überprüfung, ob Spieler springen kann
        {
            rb.velocity = Vector2.zero; // Setzt die vertikale Geschwindigkeit auf Null
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
            jumpCount++; // Inkrementiert die Anzahl der Sprünge
        }

        kamera.transform.position = new Vector3(transform.position.x, 0, -10);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    public void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "ground")
        {
            isgrounded = true;
            jumpCount = 0; // Setzt die Anzahl der Sprünge zurück, wenn der Spieler den Boden berührt
        }
        if (Collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            //panel.SetActive(true);
            transform.position = respawnPoint;
        }
        else if (Collision.gameObject.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Spike")
        {
            //panel.SetActive(true);
            //Destroy(gameObject);
            transform.position = respawnPoint;
        }
        else if (Collision.gameObject.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }

        if (Collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (Collision.gameObject.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }

        // while(other.gameObject.tag == "Teleporter")
        {
            //Destroy(gameObject);
            // planetele.SetActive(true);
        }
    }






}