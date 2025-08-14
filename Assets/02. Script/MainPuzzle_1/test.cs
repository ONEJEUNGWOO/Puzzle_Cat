using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 curDir;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void Start()
    //{
    //    rb.AddTorque(Vector3.right * 50, ForceMode.Impulse);
    //}

    //private void FixedUpdate()
    //{
    //    curDir = rb.velocity.normalized;

    //    if (curDir == Vector3.left)
    //        rb.AddTorque(Vector3.left * 50, ForceMode.Impulse);
    //    else if (curDir == Vector3.right)
    //        rb.AddTorque(Vector3.right * 50, ForceMode.Impulse);
    //    else if (curDir == Vector3.forward)
    //        rb.AddTorque(Vector3.forward * 50, ForceMode.Impulse);
    //    else if(curDir == Vector3.back)
    //        rb.AddTorque(Vector3.back * 50, ForceMode.Impulse);
    //}

    void SpeedUp()
    {
        rb.velocity = rb.velocity * speed;
    }
}
