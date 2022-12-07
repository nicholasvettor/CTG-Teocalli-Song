using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayRandomSong : MonoBehaviour
{
    public List <AudioSource> audioSourceList = new List<AudioSource> ();

    public AudioSource currentAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        int randomSong = Random.Range(0,audioSourceList.Count);

        AudioSource songToplay = audioSourceList[randomSong];

        songToplay.Play();

        currentAudioSource = songToplay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentAudioSource.isPlaying)
        {
            if (audioSourceList.Count > audioSourceList.IndexOf(currentAudioSource) + 1)
            {
                AudioSource songToPlay = audioSourceList[audioSourceList.IndexOf(currentAudioSource) + 1];
                currentAudioSource = songToPlay;
                songToPlay.Play();
            }
            else
            {
                AudioSource songToPlay = audioSourceList[0];
                currentAudioSource = songToPlay;
                songToPlay.Play();
            }

            
        }
    }
}
