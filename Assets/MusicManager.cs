using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    public int i;
    public bool active = false;

    public AudioClip head;
    public AudioClip body;
    public AudioClip tail;

    public void SetActive()
    {
        i = 1;
        active = true;
    }
    public void Increase()
    {
        i++;
    }
    public void Stop()
    {
        active = false;
        source.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying && active)
        {
            switch (i)
            {
                case 1:
                    source.clip = head;
                    source.Play();
                    return;
                case 2:
                    source.clip = body;
                    source.Play();
                    return;
                case 3:
                    source.clip = tail;
                    source.Play();
                    return;
                case 4:
                    source.clip = tail;
                    source.Play();
                    return;

            }
        }
    }
}
