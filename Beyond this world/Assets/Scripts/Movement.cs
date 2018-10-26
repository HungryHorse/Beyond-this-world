using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    public bool isGrounded;
    public float landDelay;

    bool ableToMove;
    float recoveryTime;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float modSpeed;
        modSpeed = speed;
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);


        if (!isGrounded)
        {
            modSpeed /= 2.5f;
        }

        if(recoveryTime > 0)
        {
            ableToMove = false;
            recoveryTime -= Time.deltaTime;
        }
        else
        {
            ableToMove = true;
        }

        if (ableToMove)
        {
            gameObject.transform.position += movement * modSpeed * Time.deltaTime;
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded && ableToMove)
        {
            Vector3 jump = new Vector3(0, 10, 0);
            rb.AddForce(jump * jumpForce);
        }

	}

    public void ImposeRecoveryTime()
    {
        recoveryTime = landDelay;
    }
}
