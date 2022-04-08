using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplanet : MonoBehaviour
{
    [SerializeField]
    private Transform targetActive;
    [SerializeField]
    private Transform targetInactive;

    public bool planetActive = false;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Vector3 initialScale;

    private IEnumerator co1;

    private float timeElapsed;
    [SerializeField]
    private float lerpDuration = 3;

    public Transform parent;

    public GameObject temp;
    public BoxCollider extraCollider;
    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.04F, 0.04F, 0.04F);
        //temp.SetActive(true);
        LeanTween.scaleY(temp, 1, 0.3f);
        extraCollider.enabled = true;
    }
    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.04F, 0.04F, 0.04F);
        //LeanTween.scale(gameObject, new Vector3(1.0f, 1.0f), 1.0f).setEase(LeanTweenType.punch);
        //temp.Tween("MoveCircle");
        LeanTween.scaleY(temp, 0, 0.3f);
        extraCollider.enabled = false;
    }

    private void OnMouseDown()
    {
        
    }

    public void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Changes position and scale of planet based on parameters
    /// </summary>
    IEnumerator MoveObject(Transform target, Vector3 targetScale, float duration = 0)
    {
        //Resets time elapsed on start
        timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            //Calculates time based on duration
            float time = timeElapsed / (lerpDuration - duration);

            parent.position = Vector3.Lerp(startPosition, target.position, time);
            transform.localScale = Vector3.Lerp(startScale, targetScale, time);

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        parent.position = target.position;
    }

    public void updateState()
    {
        //Set start settings for ieunumerator
        startPosition = parent.position;
        startScale = transform.localScale;

        //toggle state
        planetActive = !planetActive;

        //if youstop mid animation this makes sure it reducts the time if animation was done it sets the time at 0
        float timeBetween = timeElapsed;
        if(timeElapsed >= lerpDuration)
        {
            timeBetween = 0;
        }

        //Checks of coroutine was still running
        if (co1 != null)
            StopCoroutine(co1);
            
        //Sets correct settings based on state
        if (planetActive)
            co1 = MoveObject(targetActive, initialScale, timeBetween);            
        else
            co1 = MoveObject(targetInactive, new Vector3(0,0,0), timeBetween);

        //Starts coroutine
        StartCoroutine(co1);
    }
}
