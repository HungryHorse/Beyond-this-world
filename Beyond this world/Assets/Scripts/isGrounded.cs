using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour {

    public Movement moveScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            if (!moveScript.isGrounded)
            {
                moveScript.isGrounded = true;
                moveScript.ImposeRecoveryTime();
            }
        }
        if (collision.gameObject.tag == "FloorSink")
        {
            moveScript.isGrounded = true;
            moveScript.setOnSink(true);
            moveScript.rb.velocity = new Vector2(0, 0);
            moveScript.ImposeRecoveryTime();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (!moveScript.isGrounded)
            {
                moveScript.isGrounded = true;
            }
        }
        if (collision.gameObject.tag == "FloorSink")
        {
            moveScript.isGrounded = true;
            moveScript.setOnSink(true);
        }
        else
        {
            moveScript.setOnSink(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            moveScript.isGrounded = false;
        }
        if (collision.gameObject.tag == "FloorSink")
        {
            moveScript.isGrounded = false;
            moveScript.setOnSink(false);
            moveScript.rb.velocity = new Vector2(0, 0);
        }
    }
}
