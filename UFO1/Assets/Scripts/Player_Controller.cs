﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        setCountText();
        winText.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
            setCountText();
            }
        }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

    

}
