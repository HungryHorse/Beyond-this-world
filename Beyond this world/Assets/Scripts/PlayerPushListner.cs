using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushListner : MonoBehaviour
{

    public AudioSource crateSound;

    private void Awake()
    {
        crateSound = GameObject.Find("Crate").GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!crateSound.isPlaying)
            {
                crateSound.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            crateSound.Stop();
        }

    }

    private void OnDisable()
    {
        crateSound.Stop();
    }
}
