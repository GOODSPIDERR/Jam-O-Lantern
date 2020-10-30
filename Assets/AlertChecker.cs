using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertChecker : MonoBehaviour
{

public GameObject blight, redLight;
    GameObject world;
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
        WorldMover mover = world.GetComponent<WorldMover>();
        if(mover.alert)
        {
            Destroy(blight);
            redLight.SetActive(true);
        }
        else
        {
            blight.SetActive(true);
            redLight.SetActive(false);
        }
    }

    // Update is called once per frame
}
