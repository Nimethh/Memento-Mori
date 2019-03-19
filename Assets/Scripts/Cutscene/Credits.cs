using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Credits : MonoBehaviour
{
    public RawImage image;
    public VideoClip videoToPlay;

    private VideoPlayer vidPlayer;
    private VideoSource vidSource;
    private AudioSource vidAudioSource;

    private GameObject continueGameObject;

    void Start()
    {
        Application.runInBackground = true;

        continueGameObject = GameObject.Find("ContinueImage");
        continueGameObject.SetActive(false);

        StartCoroutine(playVid());
        
    }

    private void Update()
    {
        if (vidPlayer.isPlaying == false && vidPlayer.isPrepared)
        {
            continueGameObject.SetActive(true);
        }
        else
        {
            continueGameObject.SetActive(false);
        }
    }

    IEnumerator playVid()
    {
        vidPlayer = gameObject.AddComponent<VideoPlayer>();
        vidAudioSource = gameObject.AddComponent<AudioSource>();
        vidPlayer.playOnAwake = false;
        vidAudioSource.playOnAwake = false;
        vidAudioSource.Pause();

        vidPlayer.source = VideoSource.VideoClip;
        vidPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        vidPlayer.EnableAudioTrack(0, true);
        vidPlayer.SetTargetAudioSource(0, vidAudioSource);

        vidPlayer.clip = videoToPlay;
        vidPlayer.Prepare();

        WaitForSeconds delayTime = new WaitForSeconds(1);
        while(!vidPlayer.isPrepared)
        {
            yield return delayTime;

            break;
        }

        image.texture = vidPlayer.texture;

        vidPlayer.Play();
        vidAudioSource.Play();

        while(vidPlayer.isPlaying)
        {
            yield return null;
        }
    }
}
