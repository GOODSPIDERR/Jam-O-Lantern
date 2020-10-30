using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    int obstacleGenerator;
    GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstacleGenerator = Random.Range(0, 2);
        GameObject newObstacle;
        switch(obstacleGenerator)
        {
            default:
                break;
            case 0:
                break;
            case 1:
                //newCreation = Instantiate(wall1, new Vector3(0, 0, transform.position.z - 6), Quaternion.identity);
                //newCreation.transform.SetParent(world.transform);
                break;
        }


    }
}
