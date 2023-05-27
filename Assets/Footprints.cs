using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftPrint;
    public GameObject RightPrint;

    public Transform leftFoot;
    public Transform rightFoot;

    public float footprintDist;
    private Vector3 lastPos;
    public bool isLeft;

    public LayerMask terrain;

    public GameObject test;
    void Start()
    {
        RaycastHit hit;
        Physics.Raycast(isLeft ? leftFoot.position : rightFoot.position, Vector3.down, out hit, float.MaxValue, terrain);
        lastPos = hit.point;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(isLeft ? leftFoot.position : rightFoot.position, Vector3.down, out hit, float.MaxValue, terrain);
        //Debug.Log(lastPos + " " + hit.point + " " + Vector3.Distance(lastPos, hit.point));
        if (Vector3.Distance(lastPos,hit.point) >= footprintDist && hit.point != Vector3.zero)
        {
            lastPos = hit.point;
            Instantiate(isLeft? LeftPrint : RightPrint, lastPos + Vector3.up*0.05f, Quaternion.identity);
            isLeft = !isLeft;
        }

    }
}
