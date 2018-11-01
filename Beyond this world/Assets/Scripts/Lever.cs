using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverNumber;
    public Sprite on;
    public Sprite off;
    public MoveGameObject move;
    public MoveGameObject moveTwo;
    public MoveGameObject ghostMoveOne;
    public MoveGameObject ghostMoveTwo;
    public SpawnCrate crate;
    public GameObject spawnedCrate;

    private bool onOff = false;
    private bool active = false;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            active = true;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = false;
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
                    if (move != null)
                    {
                        move.CreateMove();
                    }
                    if (moveTwo != null)
                    {
                        moveTwo.CreateMove();
                    }
                    if (ghostMoveOne != null)
                    {
                        ghostMoveOne.CreateMove();
                    }
                    if (ghostMoveTwo != null)
                    {
                        ghostMoveTwo.CreateMove();
                    }
                    gameObject.GetComponent<SpriteRenderer>().sprite = off;
                    onOff = false;
                    break;
                case 2:
                    if (spawnedCrate == null)
                    {
                        crate.Spawn();
                    }
                    break;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = off;
            onOff = false;

            switch (leverNumber)
            {
                case 1:
                    if (move != null)
                    {
                        move.MoveBack();
                    }
                    if (moveTwo != null)
                    {
                        moveTwo.MoveBack();
                    }
                    if (ghostMoveOne != null)
                    {
                        ghostMoveOne.MoveBack();
                    }
                    if (ghostMoveTwo != null)
                    {
                        ghostMoveTwo.MoveBack();
                    }
                    break;
            }
        }

    }
}
