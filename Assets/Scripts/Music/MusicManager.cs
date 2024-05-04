using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    [Header("Manager Variables")]
    public bool playMusic = true;
    public GameObject muteToggle;

    [Header("Music List ")]
    public List<AudioClip> musicList;
    public int musicListCount;
    public int currentTrackSelectedNumber;
    public string currentTrackName;
    public float trackLength;

    [Header("Music Audio Source")]
    public AudioSource musicAudioSource;
    [Range(0.0f, 1.0f)]
    public float volume = 0.5f;
    public float audioSourcePlaytime;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize list function call
        RandomizeList();

        currentTrackSelectedNumber = musicList.IndexOf(musicList.First());
        musicListCount = musicList.Count - 1;

        // Audio Source Component
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = volume;
        musicAudioSource.clip = musicList.ElementAt(currentTrackSelectedNumber);
        // Getting the state of the mute toggle
        if (muteToggle != null)
        {
            musicAudioSource.mute = muteToggle.GetComponent<MuteToggle>().isToggleOn;
        }

        // Inspector info loading
        currentTrackName = musicAudioSource.clip.name;
        trackLength = musicAudioSource.clip.length;

        // Playing music based on playMusic bool
        if (playMusic)
        {
            PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Controlling the mute of musicAudioSource
        if (muteToggle != null)
        {
            musicAudioSource.mute = muteToggle.GetComponent<MuteToggle>().isToggleOn;
        }

        // Setting Audio Source Volume
        if (volume != musicAudioSource.volume)
        {
            musicAudioSource.volume = volume;
        }
        // Update Audio Source playtime in the global variable exposed to the inspector
        audioSourcePlaytime = musicAudioSource.time;
        // Check if the track is still playing or it finished
        if (audioSourcePlaytime >= trackLength)
        {
            StopMusic();
            NextTrack();
            if (playMusic)
            {
                PlayMusic();
            }
        }
    }

    // Functions
    public void NextTrack()
    {
        if (currentTrackSelectedNumber < musicList.Count - 1)
        {
            currentTrackSelectedNumber++;
        }
        else if (currentTrackSelectedNumber >= musicList.Count - 1)
        {
            currentTrackSelectedNumber = musicList.IndexOf(musicList.First());
        }
        musicAudioSource.clip = musicList.ElementAt(currentTrackSelectedNumber);
        currentTrackName = musicAudioSource.clip.name;
        trackLength = musicAudioSource.clip.length;
    }

    public void PlayMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Play();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void PauseMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Pause();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void StopMusic()
    {
        if (musicAudioSource.clip != null)
        {
            musicAudioSource.Stop();
        }
        else
        {
            Debug.Log("Audio Source Clip is null!");
        }
    }

    public void RandomizeList()
    {
        int n = musicList.Count;
        System.Random rng = new System.Random();

        // Fisher-Yates shuffle algorithm
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AudioClip value = musicList[k];
            musicList[k] = musicList[n];
            musicList[n] = value;
        }
    }
}
