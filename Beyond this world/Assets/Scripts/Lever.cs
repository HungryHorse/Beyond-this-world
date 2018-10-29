using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverNumber;
    public Sprite on;
    public Sprite off;
    public MoveGameObject move;

    private bool onOff = false;
    private bool active = false;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            active = true;
        } 
    }

    private void Update()
    {
        if(active && Input.GetKeyDown(KeyCode.E) )
        {
            Activate();
        }
    }

    void Activate()
    {
        if (!onOff)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = on;
            onOff = true;


            switch (leverNumber)
            {
                case 1:
                    Debug.Log("case1");
                    move.Move();
                    break;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = off;
            onOff = false;
        }

    }
}
