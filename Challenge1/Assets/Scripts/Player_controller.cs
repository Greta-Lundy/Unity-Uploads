using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text amountText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int amount;
    private int lives;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        amount = 0;
        lives = 3;
        SetCountText ();
        SetAmountText();
        SetLivesText();
        winText.text = "";
    }

    void Update ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            amount = amount + 1;
            SetCountText ();
            SetAmountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            lives = lives - 1;
            SetLivesText();
            SetCountText();
            
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString ();
        if (count >= 24)
        {
            winText.text = "Victory!";
        }
        else if (lives <= 0)
        {
            winText.text = "You lose :(";
            gameObject.SetActive(false);
        }
    }
    void SetAmountText()
    {
        amountText.text = "Blocks: " + amount.ToString() + " / 24";
        if (amount == 12)
        {
            transform.position = new Vector3(66, 0.0f, 0.0f);
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}

