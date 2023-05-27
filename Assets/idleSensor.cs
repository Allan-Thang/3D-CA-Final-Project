using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleSensor : MonoBehaviour
{
    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("lb_bird"))
            return;
        if (!other.gameObject.tag.Equals("Player"))
            return;
        controller.SetBool("idleReady", true);
        controller.SetBool("walkReady", false);
        controller.SetBool("lookAroundReady", false);
        controller.SetBool("inspectReady", false);
        controller.SetBool("shootingReady", false);
        controller.SetBool("terrifiedReady", false);
    }
}
