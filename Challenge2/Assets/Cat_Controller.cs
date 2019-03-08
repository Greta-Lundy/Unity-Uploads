using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Controller : MonoBehaviour
{

    Animator anim;
    SpriteRenderer Srender;
    private Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        Srender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("state", 1);
            Srender.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("state", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("state", 1);
            Srender.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("state", 0);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetInteger("state", 1);
                Srender.flipX = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetInteger("state", 1);
                Srender.flipX = true;
            }
            else
            {
                anim.SetInteger("state", 0);
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetInteger("state", 2);
            }
           
        }
    }
}