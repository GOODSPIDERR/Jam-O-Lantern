using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sfxDeath;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), transform.TransformDirection(Vector3.back), out hit, 0.1f))
        {
            if (hit.transform.tag == "Environment" || hit.transform.tag == "Obstacle")
            {
                AudioUtility.PlayOneShotWithRandomization(audioSource, sfxDeath, 1);
                SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1f;
            }   
        }
    }
}
