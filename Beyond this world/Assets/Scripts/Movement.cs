using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    public bool isGrounded;
    public float landDelay;
    public Sprite fallingSprite;
    public Sprite walkingSprite;
    public AudioSource jumpSound;

    private Animator animator;
    private bool onSink;
    private bool ableToMove;
    private float recoveryTime;
    public Rigidbody2D rb;
    private SpriteRenderer renderer;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float modSpeed;
        modSpeed = speed;
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            renderer.flipX = true;
        }
        else if (x > 0)
        {
            renderer.flipX = false;
        }

        if(x < -0.1 || x > 0.1)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        Vector3 movement = new Vector3(x, 0, 0);

        if (onSink)
        {
            rb.gravityScale = 0.05f;
        }
        else
        {
            rb.gravityScale = 1;
        }


        if(!isGrounded || onSink)
        {
            modSpeed /= 1.5f;
        }

        if (!isGrounded && !animator.GetBool("Ghost"))
        {
            renderer.sprite = fallingSprite;
            animator.enabled = false;
        }
        else if (!animator.GetBool("Ghost"))
        {
            renderer.sprite = walkingSprite;
            animator.enabled = true;
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.enabled = true;
            animator.Play("GhostWalk");
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
            animator.SetBool("Jump", true);
            jumpSound.Play();
        }

	}

    public void ImposeRecoveryTime()
    {
        recoveryTime = landDelay;
    }

    public void setOnSink(bool change)
    {
        onSink = change;
    }
}
