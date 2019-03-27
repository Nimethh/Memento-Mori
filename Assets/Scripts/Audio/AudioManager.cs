using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

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
    private PlayerUpgradeController upgradeController;
    [SerializeField]
    private float headUpgradeTimer;
    private float headUpgradeCoolDown;

    void Start()
    {
        Play("Background");

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2With" || SceneManager.GetActiveScene().name == "Level2Without" ||
                SceneManager.GetActiveScene().name == "Level1M" || SceneManager.GetActiveScene().name == "Level2WithM" || SceneManager.GetActiveScene().name == "Level2WithoutM")
                eS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

            upgradeController = GameObject.Find("Player").GetComponent<PlayerUpgradeController>();

            headUpgradeCoolDown = headUpgradeTimer;
        }
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
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2With" || SceneManager.GetActiveScene().name == "Level2Without" ||
                SceneManager.GetActiveScene().name == "Level1M" || SceneManager.GetActiveScene().name == "Level2WithM" || SceneManager.GetActiveScene().name == "Level2WithoutM")
            {
                if (eS.IsCommanderSpawned() == true)
                {
                    if (commanderMusicIsPlaying == false)
                    {
                        foreach (Audio aud in soundFX)
                        {
                            if (aud.name == "Background")
                            {
                                Debug.Log("Found the background");
                                aud.aS.volume = 0.0f;
                            }
                        }
                        Play("CommanderMusic");
                        commanderMusicIsPlaying = true;
                    }
                }
            }
            

            if (upgradeController.HeadUpgradeIsEquipped() == true)
            {

                if (headUpgradeCoolDown <= 0.0f)
                {
                    Play("HeadUpgradeSound");
                    headUpgradeCoolDown = headUpgradeTimer;
                }
                else
                {
                    headUpgradeCoolDown -= Time.deltaTime;
                }
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
