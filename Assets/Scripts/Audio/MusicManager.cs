using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Variable Declarations
    [Header("AUDIO SOURCES")]
    [SerializeField] private AudioSource audioSource01;
    [SerializeField] private AudioSource audioSource02;
    [SerializeField] private AudioSource audioSourceTransition;
    [Header("MATT'S CLIPS")]
    [SerializeField] private AudioClip matt01;
    [SerializeField] private AudioClip matt02;
    [SerializeField] private AudioClip matt03;
    [SerializeField] private AudioClip mattTransition;
    [Header("MICHELLE'S CLIPS")]

    [Header("AUSTIN'S CLIPS")]

    //STORAGE CONDITIONAL VARIABLES
    private AudioClip loop00;
    private AudioClip loop01;
    private AudioClip loop02;
    private AudioClip loop03;
    private AudioClip loopTransition01;
    private AudioClip loopTransition02;
    private AudioClip loopTransition03;
    private float bpm01;
    private float bpm02;
    private float bpm03;

    //FINAL STORAGE VARIABLES:
    private float bpm;
    private AudioClip _nextLoopClip;
    private AudioClip _nextTransitionClip;
    private AudioSource _nextLoopSource;
    private AudioSource _nextTransitionSource;
    private AudioSource _nextStopSource;

    //MATT'S BPMs:
    private float mattBpm01 = 170;
    private float mattBpm02 = 172;
    private float mattBpm03 = 174;
    //MICHELLE's BPMs:

    //AUSTIN's BPMs:

    //MUSIC TRACKING:
    private double barDuration;
    private double remainder;
    private double nextBarTime;

    public int musicSection;
    //public int musicSelection;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        MusicSelection(Random.Range(0 ,0));
        audioSource01.clip = loop00;
        audioSource01.Play();
        _nextStopSource = audioSource01;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAssignments();

        TrackMusicBars(_nextStopSource, bpm, 4);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransitionOnNextDownbeat(_nextStopSource, _nextTransitionSource, _nextTransitionClip, _nextLoopSource, _nextLoopClip);
            print("TRANSITION ON NEXT DOWNBEAT");
        }
    }

    #region Music Transition Logic
    private void TrackMusicBars(AudioSource audioSource, float bpm, int timeSignature)
    {
        //Calculates bar duration
        barDuration = 60d / bpm * timeSignature;

        //Calculates remainder between total elapsed time and bar duration
        remainder = ((double)audioSource.timeSamples / audioSource.clip.frequency) % barDuration;

        //Uses dspTime to set the next bar start time
        nextBarTime = AudioSettings.dspTime + barDuration - remainder;
    }

    private void TransitionOnNextDownbeat(AudioSource stopSource, AudioSource transitionSource, AudioClip transitionClip,
        AudioSource loopSource, AudioClip loopClip)
    {
        //Stop current loop
        stopSource.SetScheduledEndTime(nextBarTime);

        //Calculates transition time
        double transitionDuration = (double)transitionClip.samples / transitionClip.frequency;

        //Assign clips to sources 
        transitionSource.clip = transitionClip;
        loopSource.clip = loopClip;

        //Concatenates transition and loop sources
        transitionSource.PlayScheduled(nextBarTime);
        loopSource.PlayScheduled(nextBarTime + transitionDuration);

        musicSection++;
    }
    #endregion

    #region Music Selection Logic
    private void MusicSelection(int musicSelection)
    {
        switch (musicSelection)
        {
            //Matt
            case 0:
                loop00 = mattTransition;
                loop01 = matt01;
                loop02 = matt02;
                loop03 = matt03;
                loopTransition01 = mattTransition;
                loopTransition02 = mattTransition;
                loopTransition03 = mattTransition;
                bpm01 = mattBpm01;
                bpm02 = mattBpm02;
                bpm03 = mattBpm03;
                break;

                //Michelle

                //Austin
        }
    }
    private void SwitchAssignments()
    {
        switch (musicSection)
        {
            case 0:
                bpm = bpm01;
                _nextStopSource = audioSource01;
                _nextLoopSource = audioSource02;
                _nextLoopClip = loop01;
                _nextTransitionSource = audioSourceTransition;
                _nextTransitionClip = loopTransition01;
                break;

            case 1:
                bpm = bpm02;
                _nextStopSource = audioSource02;
                _nextLoopSource = audioSource01;
                _nextLoopClip = loop02;
                _nextTransitionSource = audioSourceTransition;
                _nextTransitionClip = loopTransition02;
                break;

            case 2:
                bpm = bpm03;
                _nextStopSource = audioSource01;
                _nextLoopSource = audioSource02;
                _nextLoopClip = loop03;
                _nextTransitionSource = audioSourceTransition;
                _nextTransitionClip = loopTransition03;
                break;
        }

    }
    #endregion
}
