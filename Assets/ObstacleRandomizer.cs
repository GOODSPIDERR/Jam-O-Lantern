using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    int obstacleGenerator;
    public GameObject obstacle1, obstacle2, obstacle3;

    // Start is called before the first frame update
    void Start()
    {
        obstacleGenerator = Random.Range(0, 10);
        GameObject newObstacle;
        switch(obstacleGenerator)
        {
            default:
                break;
            case 0:
                newObstacle = Instantiate(obstacle1, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(transform);
                break;
            case 1:
                newObstacle = Instantiate(obstacle2, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(transform);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
