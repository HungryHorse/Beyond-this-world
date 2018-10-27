using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 MoveTo;
    public float smoothing;

    void LateUpdate()
    {
        MoveTo = new Vector3(target.position.x, target.position.y + 1.25f, transform.position.z);
        transform.position = Vector3.Lerp(gameObject.transform.position, MoveTo, 0.01f * smoothing);

    }
}
