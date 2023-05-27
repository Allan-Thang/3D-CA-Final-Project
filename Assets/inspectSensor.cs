using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inspectSensor : MonoBehaviour
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
        controller.SetBool("inspectReady", true);
        controller.SetBool("idleReady", false);
        controller.SetBool("walkStopReady", false);
    }

}
