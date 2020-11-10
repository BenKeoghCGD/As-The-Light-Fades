using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{

    public VideoPlayer vp;

    [Header("Videos")]
    public VideoClip staticVideo;
    public VideoClip video;

    void Start()
    {
        vp.clip = staticVideo;
        vp.Play();
    }

    private void Update()
    {

        if(vp.clip == staticVideo)
        {
            if (!vp.isPlaying) vp.Play();
        }
    }

    public IEnumerator playEE()
    {
        vp.clip = video;
        yield return new WaitForSecondsRealtime(3);
        while (!vp.isPrepared) yield return null;
        while (vp.isPlaying)
        {
            Debug.Log("PLAYING");
            yield return null;
        }
        vp.clip = staticVideo;
        vp.Play();
    }
}
