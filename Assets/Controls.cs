using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    bool landed = true;
    Rigidbody rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey("space") && landed)
        {
            rb.velocity = new Vector3(0,3.5f,0);
            animator.Play("PancakeJump");
        }

        if(System.Math.Round(rb.velocity.y,2) == 0)
        {
            landed = true;
            animator.Play("PancakeRun");
        }
        else
        {
            landed = false;
        }

    }
}
