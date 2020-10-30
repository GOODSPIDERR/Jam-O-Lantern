using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    Text text;
    GameObject world;
    WorldMover mover;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        world = GameObject.Find("World");
        mover = world.GetComponent<WorldMover>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = mover.score.ToString();
    }
}
