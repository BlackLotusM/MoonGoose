using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cameraWarp
{
    public string name;
    [SerializeField]
    public int startIndex = 0;
    [SerializeField]
    private int cameraDimension;
    [SerializeField]
    public cameraIndex[] cameraPosition;
}

[System.Serializable]
public class cameraIndex
{
    [SerializeField]
    private string name;
    [SerializeField]
    public int index;
    [SerializeField]
    public Transform cameraPos;
}

public class CameraPositioner : MonoBehaviour
{
    public int currentIndex;
    public int currentDimension;
    public cameraWarp[] cameraData;
    [SerializeField]
    private Camera mainCam;
    private IEnumerator running;
    private IEnumerator runningDim;
    public float time;

    private void Start()
    {
        mainCam = Camera.main;
        //currentIndex = 0;
        mainCam.transform.position = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.position;
        mainCam.transform.rotation = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentIndex - 1 > -1)
            {
                if (running != null)
                    StopCoroutine(running);
                currentIndex--;
                running = MoveCamTo();
                StartCoroutine(running);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentIndex + 1 <= cameraData[currentDimension].cameraPosition.Length - 1)
            {
                if (running != null)
                    StopCoroutine(running);
                currentIndex++;
                running = MoveCamTo();
                StartCoroutine(running);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentDimension - 1 >= 0)
            {
                if (runningDim != null)
                    StopCoroutine(runningDim);
                currentDimension--;
                runningDim = MoveCamDimension();
                StartCoroutine(runningDim);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentDimension + 1 <= cameraData.Length - 1)
            {
                if (runningDim != null)
                    StopCoroutine(runningDim);
                currentDimension++;
                runningDim = MoveCamDimension();
                StartCoroutine(runningDim);
            }
        }
    }

    private IEnumerator MoveCamTo()
    {
        Vector3 startingPos = mainCam.transform.position;
        Vector3 finalPos = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.position;

        Quaternion startingRotation = mainCam.transform.rotation;
        Quaternion finalRotation = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.rotation;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mainCam.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            mainCam.transform.rotation = Quaternion.Lerp(startingRotation, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator MoveCamDimension()
    {
        mainCam.enabled = false;
        yield return new WaitForSeconds(2);
        mainCam.transform.position = cameraData[currentDimension].cameraPosition[cameraData[currentDimension].startIndex].cameraPos.transform.position;
        mainCam.transform.rotation = cameraData[currentDimension].cameraPosition[cameraData[currentDimension].startIndex].cameraPos.transform.rotation;
        currentIndex = cameraData[currentDimension].startIndex;
        mainCam.enabled = true;
    }
}
