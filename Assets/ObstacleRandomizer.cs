using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{

    public GameObject obstacle1, obstacle2, obstacle3, obstacle4, obstacle5, world;
    public int obstacleGenerator = 0;
    public int generatorMax = 11;
    public WorldMover worldMover;
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
        worldMover = world.GetComponent<WorldMover>();
        obstacleGenerator = Random.Range(0, generatorMax);
        Debug.Log("Obstacle generated: " + obstacleGenerator);
        GameObject newObstacle;
        switch(obstacleGenerator)
        {
            default:
                obstacleGenerator = 0;
                break;
            case 0:
                obstacleGenerator = 0;
                break;
            case 1:
                newObstacle = Instantiate(obstacle1, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(world.transform);
                break;
            case 2:
                newObstacle = Instantiate(obstacle2, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(world.transform);
                break;
            case 3:
                newObstacle = Instantiate(obstacle3, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(world.transform);
                break;
            case 4:
                newObstacle = Instantiate(obstacle4, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(world.transform);
                break;
            case 5:
                newObstacle = Instantiate(obstacle5, new Vector3(0, 0, transform.position.z), Quaternion.identity);
                newObstacle.transform.SetParent(world.transform);
                break;
        }
    }

    private void Update() 
    {
        if(worldMover.alert)
        {
            generatorMax = 7;
        }
        else
        {
            generatorMax = 11;
        }
    }
}
