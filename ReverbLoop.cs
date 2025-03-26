using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbLoop : MonoBehaviour
{
    public int bars; //total number of bars AKA measures in the track NOT INCLUDING REVERB TAIL
    public int bpm; //bpm of the track
    public int beatsInMeasure; //beats per measure in the track, so 3 for a song in 3/4 time
    public int extraBeats; //if the loop length is not a neat bar count add extra beats here
    private double beatlength;
    private double barlength;
    private double repeatlength;
    private double goTime;
    private bool zero;

    [Tooltip("The 2 audio sources should be the same track each with reverb tail baked in. They will alternate to create a seamless loop.")]
    public List<AudioSource> trackDupes; //it's a list but make it have exactly 2 entries. you need 2 different audio sources with the same audio clip because it needs to alternate between them

    private void Start()
    {
        goTime = AudioSettings.dspTime + 0.5;
        Calculate();
    }
    private void Calculate()
    {
        beatlength = 60d / bpm;
        barlength = beatlength * beatsInMeasure;
        repeatlength = (barlength * bars) + (beatlength * extraBeats);
    }

    private void Prepare()
    {
        if (zero)
        {
            //the last playscheduled we did was for the zeroeth one
            trackDupes[1].PlayScheduled(goTime);
        }
        else
        {
            trackDupes[0].PlayScheduled(goTime);
        }
        goTime = goTime + repeatlength;
        zero = !zero;
    }

    private void Update()
    {
        if (AudioSettings.dspTime > goTime - 1)
        {
            Prepare();
        }
    }
}
