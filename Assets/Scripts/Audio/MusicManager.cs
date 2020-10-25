using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    double barDuration;
    double remainder;
    double nextBarTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConcatenateIntroAndLoop(AudioSource introSource, AudioClip introClip, AudioSource Source, AudioClip loopCLip)
    {
        //Calculates intro duration
        double introDuration = (double)introClip.samples / introClip.frequency;

        //Assign clips to sources
        introSource.clip = introClip;
        Source.clip = loopCLip;

        //Concatenate intro and loop sources
        introSource.PlayScheduled(AudioSettings.dspTime + 0.1);
        Source.PlayScheduled(AudioSettings.dspTime + 0.1 + introDuration);
    }

    private void TrackMusicBars(AudioSource audioSource, int bpm, int timeSignature)
    {
        //Calculates bar duration
        barDuration = 60d / bpm * timeSignature;

        //Calculates remainder between total elapsed time and bar duration
        remainder = ((double)audioSource.timeSamples / audioSource.clip.frequency) % barDuration;

        //Uses dspTime to set the next bar start time
        nextBarTime = AudioSettings.dspTime + barDuration - remainder;
    }

    public void TransitionOnNextDownbeat(AudioSource stopSource, AudioSource transitionSource, AudioClip transitionClip,
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
    }
}
