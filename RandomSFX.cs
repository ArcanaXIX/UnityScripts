using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFX : MonoBehaviour
{
    // note for math nerds - for an equal chance of all SFX, add an extra audio source to the list
    // and make the last entry a duplicate of the first
    [Tooltip("List of SFX variations as Audio Sources to randomly choose from")]
    public List<AudioSource> sfxList;

    private float rand;
    private int listNum;
    private int i;

    private void Start() //on Start, looks at how many SFX there are in the list to choose from
    {
        listNum = sfxList.Count - 1;
    }

    // on game events where you want a randomized sound effect,
    // call this method - RandomSFX.RandomPlay() - instead of a specific AudioSource.Play()
    // it will play one randomly from a list, allowing for variation

    public void RandomPlay() 
    {
        rand = Random.Range(0.0f, 1.0f); //generates random number between 0-1
        i = Mathf.RoundToInt(rand * listNum); //converts that number in 0-1 range to 0-[list max] then rounds to nearest int
        sfxList[i].Play(); //plays the audio source associated with the random int
    }
}
