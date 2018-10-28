using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private Transform cameraPos;
    private Transform target;
    

	// Use this for initialization
	void Start () {
        cameraPos = Camera.main.transform;
        target.position = new Vector3(cameraPos.position.x, cameraPos.position.y);
	}
	
	// Update is called once per frame
	void Update () {

        transform.GetChild(0).position = target.position;
		
	}
}
