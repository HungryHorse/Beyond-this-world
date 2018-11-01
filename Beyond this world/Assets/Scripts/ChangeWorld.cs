using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour {

    public AudioSource toGhost;
    public AudioSource toHuman;
    public GameObject realWorld;
    public GameObject ghostWorld;
    public float changeDelay;
    public bool human = true;

    private Animator animator;
    bool ableToSwitch;
    float switchRecovery;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


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
        human = !human;
        animator.enabled = true;
        realWorld.SetActive(!realWorld.activeInHierarchy);
        ghostWorld.SetActive(!ghostWorld.activeInHierarchy);
        animator.SetBool("Ghost", !animator.GetBool("Ghost"));
        switchRecovery = changeDelay;
        if (human)
        {
            toHuman.Play();
        }
        else
        {
            toGhost.Play();
        }
    }
}
