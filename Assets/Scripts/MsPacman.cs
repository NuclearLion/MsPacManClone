using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MsPacman : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(-1, 0) * speed;
    }

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown("a"))
        {
            rb.velocity = new Vector2(horzMove, 0) * speed;

            transform.localScale = new Vector2(1, 1);

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (Input.GetKeyDown("d"))
        {
            rb.velocity = new Vector2(horzMove, 0) * speed;

            transform.localScale = new Vector2(-1, 1);

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector2(0, vertMove) * speed;

            transform.localScale = new Vector2(1, 1);

            transform.localRotation = Quaternion.Euler(0, 0, 270);
        } else if (Input.GetKeyDown("s"))
        {
            rb.velocity = new Vector2(0, vertMove) * speed;

            transform.localScale = new Vector2(1, 1);

            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

    }

}
