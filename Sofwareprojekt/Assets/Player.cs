using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;
    private bool doubleJumped = false; // Neue Variable für Double Jump hinzugefügt

    private Animator anim;
    private Vector3 rotation;

    public GameObject panel;
    public GameObject kamera;
    public GameObject planetele;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
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
            doubleJumped = false; // Reset doubleJumped auf false, da Spieler wieder auf dem Boden ist
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isgrounded && !doubleJumped) // Wenn Spieler nicht auf dem Boden ist und noch nicht double jumped hat
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Stoppt aktuelle vertikale Bewegung
            rb.AddForce(Vector2.up * jumph * 0.6f, ForceMode2D.Impulse); // Fügt geringere Kraft für Double Jump hinzu
            doubleJumped = true;
        }

        kamera.transform.position = new Vector3(transform.position.x, 0, -10);
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
    }
}