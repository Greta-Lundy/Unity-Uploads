using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jump;
    public Transform secondstart;
    public GameObject camera;
    public Transform cameramover;
    public GameObject woosh;

    private int count;
    private int lives;
    public Text countText;
    public Text winText;
    public Text livesText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        setCountText();
        setLivesText();
        winText.text = "";
        woosh.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            setLivesText();
        }
    }
    

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
        }
    }

    void setLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            winText.text = "You Lose";
            gameObject.SetActive(false);
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 4)
        {
            transform.position = secondstart.position;
            camera.transform.position = cameramover.position;
            resetLives();
        }
        if (count >= 8)
        { 
            winText.text = "You Win!";
            woosh.gameObject.SetActive(true);
        }
        
    }

    void resetLives()
    {
        lives = 3;
        setLivesText();
    }
}
