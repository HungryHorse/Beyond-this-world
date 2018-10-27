using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverNumber;

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
        if(active && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }
    }

    void Activate()
    {
        switch (leverNumber)
        {
            case 1:

                break;
        }

    }
}
