using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloActivate : MonoBehaviour
{
    public Moveplanet[] planets;
    public ParticleSystem particle;

    private void OnMouseDown()
    {
        foreach(Moveplanet planet in planets)
        {
            planet.updateState();
        }
    }
    private void Update()
    {
        if (planets[1].planetActive)
        {
            if (particle.gameObject.transform.localScale.x < 1)
            {
                var vec = particle.gameObject.transform.localScale;
                vec.x += 0.008f;
                vec.z = vec.x;
                vec.y = vec.x;
                particle.gameObject.transform.localScale = vec;
            }
        }
        else
        {
            if (particle.gameObject.transform.localScale.x > -0.1)
            {
                var vec = particle.gameObject.transform.localScale;
                vec.x -= 0.008f;
                vec.z = vec.x;
                vec.y = vec.x;
                particle.gameObject.transform.localScale = vec;
            }
        }
    }
}
