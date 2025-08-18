using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int layer;
    public float speed;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -20f, 0f);    //게임매니저에서 관리해야 함
    }

    private void Update()
    {
        if (!Physics.CheckSphere(transform.position, 0.5f, 1<<LayerMask.NameToLayer("Puzzle")))
        {
            AddForce();
        }
    }

    private void AddForce()
    {
        var force = Vector3.up * 6f;
        rb.AddForce(force);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
