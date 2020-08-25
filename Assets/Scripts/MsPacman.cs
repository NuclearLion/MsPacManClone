using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MsPacman : MonoBehaviour
{

    public float speed = 4f;
    private Rigidbody2D rb;
    public Sprite pausedSprite;

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

        Vector2 moveVect;
        
        var localVelocity = transform.InverseTransformDirection(rb.velocity);

        if (Input.GetKeyDown("a"))
        {
            if (localVelocity.x > 0)
            {
                moveVect = new Vector2(horzMove, 0);

                transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                rb.velocity = moveVect * speed;

                transform.localScale = new Vector2(1, 1);

                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else
            {
                moveVect = new Vector2(horzMove, 0);

                if (canIMoveInDirection(moveVect))
                {
                    transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                    rb.velocity = moveVect * speed;

                    transform.localScale = new Vector2(1, 1);

                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        else if (Input.GetKeyDown("d"))
        {

            if (localVelocity.x < 0)
            {
                moveVect = new Vector2(horzMove, 0);

                transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                rb.velocity = moveVect * speed;

                transform.localScale = new Vector2(-1, 1);

                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else
            {
                moveVect = new Vector2(horzMove, 0);

                if (canIMoveInDirection(moveVect))
                {
                    transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                    rb.velocity = moveVect * speed;

                    transform.localScale = new Vector2(-1, 1);

                    transform.localRotation = Quaternion.Euler(0, 0, 0);

                }
            }

        }
        else if (Input.GetKeyDown("w"))
        {
            if (localVelocity.y > 0)
            {
                moveVect = new Vector2(0, vertMove);

                transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                rb.velocity = moveVect * speed;
                transform.localScale = new Vector2(1, 1);
                transform.localRotation = Quaternion.Euler(0, 0, 270);

            }
            else
            {
                moveVect = new Vector2(0, vertMove);

                if (canIMoveInDirection(moveVect))
                {
                    transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                    rb.velocity = moveVect * speed;
                    transform.localScale = new Vector2(1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, 270);

                }
            }


        }
        else if (Input.GetKeyDown("s"))
        {

            if (localVelocity.y < 0)
            {
                moveVect = new Vector2(0, vertMove);
                transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                rb.velocity = moveVect * speed;

                transform.localScale = new Vector2(1, 1);

                transform.localRotation = Quaternion.Euler(0, 0, 90);

            }
            else
            {
                moveVect = new Vector2(0, vertMove);

                if (canIMoveInDirection(moveVect))
                {
                    transform.position = new Vector2((int)transform.position.x + .5f, (int)transform.position.y + .5f);

                    rb.velocity = moveVect * speed;
                    transform.localScale = new Vector2(1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }
        UpdateEatingAnimation();
    }

    bool canIMoveInDirection(Vector2 dir)
    {
        Vector2 pos = transform.position;

        Transform point = GameObject.Find("GBGrid").GetComponent<Gameboard>().gBPoints[(int)pos.x, (int)pos.y];

        if (point != null)
        {
            GameObject pointGO = point.gameObject;

            Vector2[] vectToNextPoint = pointGO.GetComponent<TurningPoint>().vectToNextPoint;

            foreach (Vector2 vect in vectToNextPoint)
            {
                if (vect == dir)
                {
                    return true;
                }
            }
        }
        return false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        bool hitAWall = false;

        if (col.gameObject.tag == "Point")
        {
            Vector2[] vectToNextPoint = col.GetComponent<TurningPoint>().vectToNextPoint;

            if (Array.Exists(vectToNextPoint, element => element == rb.velocity.normalized))
            {
                hitAWall = false;
            }
            else
            {
                hitAWall = true;
            }

            transform.position = new Vector2((int)col.transform.position.x + .5f, (int)col.transform.position.y + .5f);

            if (hitAWall)
                rb.velocity = Vector2.zero;

        }

    }

    void UpdateEatingAnimation()
    {
        if (rb.velocity == Vector2.zero)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = pausedSprite;
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }
    }

}