using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("rotate", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotate = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if (Quaternion.Angle(lookRotate,transform.rotation) > 10)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotate, 180 * Time.deltaTime);
    }

    public void rotate()
    {

        transform.LookAt(transform.position + Vector3.down, Vector3.forward);
    }
}
