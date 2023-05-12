using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieSensorBlake : MonoBehaviour
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
        controller.SetBool("deadReady", true);
        controller.SetBool("pistolIdleReady", false);
    }
}
