using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {


    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloorSink")
        {
            rb.gravityScale = 0.01f;
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FloorSink")
        {
            rb.gravityScale = 0.05f;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
}
