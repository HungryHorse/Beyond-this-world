using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour {

    public GameObject realWorld;
    public GameObject ghostWorld;
    public float changeDelay;

    bool ableToSwitch;
    float switchRecovery;


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ableToSwitch)
        {
            SwitchPlane();
        }

        if (switchRecovery > 0)
        {
            switchRecovery -= Time.deltaTime;
            ableToSwitch = false;
        }
        else
        {
            ableToSwitch = true;
        }
	}

    void SwitchPlane()
    {
        realWorld.SetActive(!realWorld.activeInHierarchy);
        ghostWorld.SetActive(!ghostWorld.activeInHierarchy);
        switchRecovery = changeDelay;
    }
}
