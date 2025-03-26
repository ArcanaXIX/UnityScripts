using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this to play an "intro" to a music piece that has a reverb tail and then transition seamlessly to the next section of a piece
//specific use case is for pieces that have an intro and then a section that loops, but the intro section has a reverb tail not baked into the loop
//the intro and loop sections must be rendered as separate audio files

//this does NOT currently combine with my reverb loop script but you could theoretically hook that up with some tweaks
//declare a public ReverbLoop instead of a public AudioSource for "loop"
//and then set the ReverbLoop goTime instead of using AudioSource.PlayScheduled
public class MusicIntro : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource loop; //it is expected that this AudioSource is already configured to loop in the editor
    public float delay = 0.5f;
    public int bars;
    public int bpm;
    public int beatsInMeasure;
    public int extraBeats;
    public bool onEnable; //check this if you want to trigger the song (intro + loop) just by enabling this object

    private double beatlength;
    private double barlength;
    private double introlength;
    private double goTime;


    
    private void OnEnable()
    {
        if (onEnable)
        {
            Queue();
        }
    }

    //use this method to start the intro and queue the loop at any time you like not just OnEnable()
    //you could even pass a double into it if you want instead of using this script's delay float, the world is your oyster
    public void Queue()
    {
        goTime = AudioSettings.dspTime + delay;
        Calculate();
        Prepare();
    }

    private void Calculate()
    {
        beatlength = 60d / bpm;
        barlength = beatlength * beatsInMeasure;
        introlength = (barlength * bars) + (extraBeats * beatlength);
    }

    private void Prepare()
    {
        intro.PlayScheduled(goTime);
        loop.PlayScheduled(goTime + introlength);
    }
}
