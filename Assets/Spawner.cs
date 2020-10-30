using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    int roomGenerator = 0;
    public GameObject wall1;
    public GameObject wall2;
    GameObject world;

    // Start is called before the first frame update

    private void Start()
    {
        world = GameObject.Find("World");
    }
    private void OnTriggerEnter(Collider other)
    {
        roomGenerator = Random.Range(0, 2);
        GameObject newCreation;
        switch (roomGenerator)
        {
            case 0:
                newCreation = Instantiate(wall1, new Vector3(0, 0, transform.position.z - 6), Quaternion.identity);
                newCreation.transform.SetParent(world.transform);
                break;
            case 1:
                newCreation = Instantiate(wall2, new Vector3(0, 0, transform.position.z - 6), Quaternion.identity);
                newCreation.transform.SetParent(world.transform);
                break;
            default:
                newCreation = Instantiate(wall1, new Vector3(0, 0, transform.position.z - 6), Quaternion.identity);
                newCreation.transform.SetParent(world.transform);
                break;
        }
    }

    // Update is called once per frame
}
