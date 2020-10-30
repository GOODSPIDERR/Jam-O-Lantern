using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    bool landed = true;
    Rigidbody rb;
    public Animator animator;

    //Audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sfxJump;
    [SerializeField] private AudioClip[] sfxLand;
    private bool wasGrounded;

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
            AudioUtility.PlayOneShotWithRandomization(audioSource, sfxJump, 1);
        }

        LandingSFX();
        isGrounded();
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

    private void isGrounded()
    {
        wasGrounded = landed;
    }

    private void LandingSFX()
    {
        if(landed && !wasGrounded)
        {
            AudioUtility.PlayOneShotWithRandomization(audioSource, sfxLand, 0.65f);
        }
    }
}
