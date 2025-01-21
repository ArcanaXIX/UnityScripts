using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFX : MonoBehaviour
{
    public List<AudioSource> sfxList;
    private float rand;
    private int listNum;
    private int i;

    private void Start() //on Start, looks at how many SFX there are
    {
        listNum = sfxList.Count - 1;
    }

    public void RandomPlay() //call this method instead of individual sfx.Play() and it will play one randomly from the list instead, allowing for variation
    {
        rand = Random.Range(0.0f, 1.0f);
        i = Mathf.RoundToInt(rand * listNum);
        sfxList[i].Play();

    }
}
