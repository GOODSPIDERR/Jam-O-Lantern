using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    bool canJump = true;
    float jumpSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey("space") && canJump)
        {
            canJump = false;
            jumpSpeed = 4f;

        }
        
        transform.Translate(0, jumpSpeed * Time.deltaTime, 0);

        if(transform.position.y > 0f)
            jumpSpeed -= 15f * Time.deltaTime;
        else
        {
            transform.position = new Vector3(0, 0, transform.position.z);
            jumpSpeed = 0f;
            canJump = true;
        }

    }
}
