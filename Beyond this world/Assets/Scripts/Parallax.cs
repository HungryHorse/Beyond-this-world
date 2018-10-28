using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float speed;
    public float imageSize;
    public float view;

    private int count;
    private Transform[] images;
    private Transform camera;
    private float lastPos;
    private int leftIndex;
    private int rightIndex;

	// Use this for initialization
	void Start ()
    {
        count = transform.childCount;
        images = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            images[i] = transform.GetChild(i);
        }
        camera = Camera.main.transform;
        lastPos = camera.position.x;
        leftIndex = 0;
        rightIndex = count - 1; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        float delta = camera.position.x - lastPos;
        transform.position += Vector3.right * (delta * speed);
        lastPos = camera.position.x;

        if (camera.position.x > images[rightIndex].position.x - (view))
        {
            shiftRight();
        }
        if (camera.position.x < images[leftIndex].position.x + (view))
        {
            shiftLeft();
        }
	}

    void shiftRight()
    {
        int lastLeft = leftIndex;
        images[leftIndex].position = Vector3.right * (images[rightIndex].position.x + imageSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == count)
        {
            leftIndex = 0;
        }
    }

    void shiftLeft()
    {
        int lastRight = rightIndex;
        images[rightIndex].position = Vector3.right * (images[leftIndex].position.x - imageSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = count - 1;
        }
    }
}
