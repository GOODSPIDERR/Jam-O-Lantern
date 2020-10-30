using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public double score = 0f;
    public bool alert = false;

    List<GameObject> lightList = new List<GameObject>();
     string nameToAdd = "Light";

     List<GameObject> redLightList = new List<GameObject>();
     string nameToAddRed = "RedLight";

    //Audio
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private AudioClip sfxAlarm;
    [SerializeField] private AudioSource audioSource;
    private bool musicSection2;
    private bool musicSection3;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        Time.timeScale += 0.005f * Time.deltaTime;
        score += 10f * Time.deltaTime;
        score = System.Math.Round(score,2);

        if(!alert && score > 150f)
        {
            musicManager.ChangeMusic();
            audioSource.PlayOneShot(sfxAlarm);
            alert = true;
            foreach(GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if(go.name == nameToAdd)
                    lightList.Add (go);
            }

            foreach(GameObject kill in lightList)
            {
                kill.SetActive(false);
            }

            foreach(GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if(go.name == nameToAddRed)
                    redLightList.Add (go);

            }

            foreach(GameObject revive in redLightList)
            {
                revive.SetActive(true);
            }

        }

        if(!musicSection2 && score > 150f + 800f)
        {
            musicManager.ChangeMusic();
            musicSection2 = true;
        }

        if (!musicSection3 && score > 150f + 800f +  800f)
        {
            musicManager.ChangeMusic();
            musicSection3 = true;
        }
    }


}
