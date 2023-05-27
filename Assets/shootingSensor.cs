using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSensor : MonoBehaviour
{
    public Animator controller;
    public Camera camera;

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
        controller.SetBool("shootingReady", true);
        controller.SetBool("idleReady", false);
        controller.SetBool("breathingidleReady", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("lb_bird"))
            return;
        if (!other.gameObject.tag.Equals("Player"))
            return;
        controller.SetBool("shootingReady", false);
        controller.SetBool("idleReady", true);
    }
}
