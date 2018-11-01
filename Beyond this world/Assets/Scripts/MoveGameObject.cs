using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObject : MonoBehaviour
{
    public float smoothing;
    public Transform target;
    public float startX;
    public AudioSource sliding;
    public bool isReal;

    private bool doMove;
    private bool moveBack;
    private bool didMove = false;
    private bool didMoveBack = true;

    private void Update()
    {
        if (doMove)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, target.position, 0.01f * smoothing);
        }
        if (moveBack)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(startX,1,0), 0.01f * smoothing);
        }

        if(Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            doMove = false;
            didMove = true;
        }
        if (Vector3.Distance(transform.position, target.position) > 4f)
        {
            moveBack = false;
            didMoveBack = true;
        }
    }

    public void CreateMove()
    {
        if (didMove)
        {
            MoveBack();
        }
        if (didMoveBack)
        {
            Move();
        }
    }

    public void Move()
    {
        if (!moveBack)
        {
            doMove = true;
            didMoveBack = false;
            if (isReal)
            {
                sliding.Play();
            }
        }
    }
    public void MoveBack()
    {
        if (!doMove)
        {
            moveBack = true;
            didMove = false;
            if (isReal)
            {
                sliding.Play();
            }
        }
    }
}
