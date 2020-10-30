using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruction", 15);
    }

    void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
