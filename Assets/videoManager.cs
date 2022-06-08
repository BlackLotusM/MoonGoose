using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoManager : MonoBehaviour
{
    public VideoClip first;
    public VideoClip second;

    public VideoPlayer player;
    public bool Started = false;
    public GameObject rawImage;
    public GameObject btn;
    
    
    public void StartClips()
    {
        player.clip = first;
        rawImage.SetActive(true);
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started && player.clip == first && !player.isPlaying)
        {
            Started = true;
        }
        else
        {
            if (Started)
            {
                if (!player.isPlaying)
                {
                    if (player.clip != second)
                    {
                        btn.SetActive(true);
                        player.clip = second;
                    }
                    player.Play();
                }
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
