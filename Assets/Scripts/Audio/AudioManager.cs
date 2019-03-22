using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource aS;
}

//followed tutorial from brackeys.
public class AudioManager : MonoBehaviour
{
    public Audio[] soundFX;
    private EnemySpawner eS;
    private bool commanderMusicIsPlaying = false;

    void Start()
    {
        Play("Background");
        eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    void Awake()
    {
        foreach(Audio aud in soundFX)
        {
            aud.aS = gameObject.AddComponent<AudioSource>();
            aud.aS.clip = aud.clip;
            aud.aS.volume = aud.volume;
            aud.aS.loop = aud.loop;
        }
    }

    void Update()
    {
        if (eS.IsCommanderSpawned() == true)
        {
            if (commanderMusicIsPlaying == false)
            {
                foreach (Audio aud in soundFX)
                {
                    if (aud.name == "Background")
                    {
                        aud.aS.volume = 0.0f;
                    }
                }
                commanderMusicIsPlaying = true;
            }
        }
    }

    public void Play(string p_name)
    {
        Audio aud = Array.Find(soundFX, Audio => Audio.name == p_name);
        if(aud == null)
        {
            Debug.Log("Audio : " + name + " not found");
            return;
        }
        aud.aS.Play();
    }
}
