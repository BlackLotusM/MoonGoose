using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vuurtorenmanager : MonoBehaviour
{
    public AudioSource source;
    
    public AudioClip normal;
    public AudioClip broken;
    public AudioClip continuebroken;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = normal;
        source.Play();
    }
    public void BreakLamp()
    {
        source.loop = false;
        source.clip = broken;
        source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying && (source.clip == broken || source.clip == continuebroken))
        {
            source.clip = continuebroken;
            source.Play();
        }
    }
}
