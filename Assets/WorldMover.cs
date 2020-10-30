using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{

    public float moveSpeed = 0.1f;
    public float score = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //score = transform.position.z * 10;
        //moveSpeed += 0.01f * Time.deltaTime;
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        Time.timeScale += 0.005f * Time.deltaTime;
    }


}
