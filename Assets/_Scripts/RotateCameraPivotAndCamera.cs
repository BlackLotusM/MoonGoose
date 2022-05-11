using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraPivotAndCamera : MonoBehaviour
{
    public GameObject firstPos;
    public GameObject navigationPanel;
    public void StartRotate()
    {
        StartCoroutine(MoveCamToObject());
    }

    public IEnumerator MoveCamToObject()
    {
        navigationPanel.SetActive(false);
        float duration = 2.0f;

        // store the initial and target rotation once
        var startRotation = transform.rotation;
        var targetRotation = Quaternion.LookRotation(new Vector3(0,0,0) - transform.position);

        for (float timePassed = 0.0f; timePassed < duration; timePassed += Time.deltaTime)
        {
            float factor = timePassed / duration;
            // optionally add ease-in and -out
            //factor = Mathf.SmoothStep(0, 1, factor);

            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, factor);
            yield return null;
        }

        navigationPanel.SetActive(true);
        // just to be sure to end up with clean values
        transform.rotation = targetRotation;
        firstPos.transform.rotation = targetRotation;
    }
}
