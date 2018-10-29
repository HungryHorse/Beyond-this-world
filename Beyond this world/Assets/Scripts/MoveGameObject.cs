using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObject : MonoBehaviour
{
    public float smoothing;
    public Transform target;

    private bool doMove;

    private void Update()
    {
        if (doMove)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, target.position, 0.01f * smoothing);
        }
    }

    public void Move()
    {
        doMove = true;
    }
}
