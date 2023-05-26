using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumebird : MonoBehaviour
{
    // Start is called before the first frame update
    public lb_Bird[] birds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(lb_Bird bird in birds)
        {
            bird.UnPauseBird();
        }
    }
}
