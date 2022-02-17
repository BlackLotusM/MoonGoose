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
    public bool done = true, atObject;

    //TEMP MOVE TO BETTER PLACE
    public GameObject canvasMap;

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
        //TEMP MOVE TO BETTER PLACE
        if (Input.GetKeyDown(KeyCode.M))
        {
            canvasMap.SetActive(!canvasMap.activeSelf);
        }
        if (atObject)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDown();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentUp();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            DimensionDown();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DimensionUp();
        }
    }

    public void currentUp()
    {
        if (currentIndex + 1 <= cameraData[currentDimension].cameraPosition.Length - 1)
        {
            if (running != null)
                StopCoroutine(running);
            currentIndex++;
            done = false;
            running = MoveCamTo();
            StartCoroutine(running);
        }
    }

    public void currentDown()
    {
        if (currentIndex - 1 > -1)
        {
            if (running != null)
                StopCoroutine(running);
            currentIndex--;
            done = false;
            running = MoveCamTo();
            StartCoroutine(running);
        }
    }

    public void targetIndex(int target)
    {
        canvasMap.SetActive(false);
        if (target > -1 && target <= cameraData[currentDimension].cameraPosition.Length - 1)
        {
            if (running != null)
                StopCoroutine(running);
            currentIndex = target;
            done = false;
            running = MoveCamTo();
            StartCoroutine(running);
        }
    }

    public void DimensionUp()
    {
        if (currentDimension + 1 <= cameraData.Length - 1)
        {
            if (runningDim != null)
                StopCoroutine(runningDim);
            done = false;
            currentDimension++;
            runningDim = MoveCamDimension();
            StartCoroutine(runningDim);
        }
    }

    public void DimensionDown()
    {
        if (currentDimension - 1 >= 0)
        {
            if (runningDim != null)
                StopCoroutine(runningDim);
            done = false;
            currentDimension--;
            runningDim = MoveCamDimension();
            StartCoroutine(runningDim);
        }
    }

    public IEnumerator MoveCamTo()
    {
        
        Vector3 startingPos = mainCam.transform.position;
        Vector3 finalPos = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.position;

        Quaternion startingRotation = mainCam.transform.rotation;
        Quaternion finalRotation = cameraData[currentDimension].cameraPosition[currentIndex].cameraPos.transform.rotation;

        if (Vector3.Distance(startingPos, finalPos) < 0.1 && Quaternion.Angle(startingRotation, finalRotation) < 0.1)
        {
            done = true;
            yield break;
        }

        time = 0.89f;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mainCam.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            mainCam.transform.rotation = Quaternion.Lerp(startingRotation, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        done = true;
    }

    public IEnumerator MoveCamToObject(Transform camPos)
    {
        time = 0.6f;
        Vector3 startingPos = mainCam.transform.position;
        Vector3 finalPos = camPos.position;

        Quaternion startingRotation = mainCam.transform.rotation;
        Quaternion finalRotation = camPos.rotation;

        if (Vector3.Distance(startingPos, finalPos) < 0.1 && Quaternion.Angle(startingRotation, finalRotation) < 0.1)
        {
            done = true;
            yield break;
        }

        time = Vector3.Distance(startingPos, finalPos) / 10;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mainCam.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            mainCam.transform.rotation = Quaternion.Lerp(startingRotation, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        done = true;
    }

    private IEnumerator MoveCamDimension()
    {
        mainCam.enabled = false;
        yield return new WaitForSeconds(2);
        mainCam.transform.position = cameraData[currentDimension].cameraPosition[cameraData[currentDimension].startIndex].cameraPos.transform.position;
        mainCam.transform.rotation = cameraData[currentDimension].cameraPosition[cameraData[currentDimension].startIndex].cameraPos.transform.rotation;
        currentIndex = cameraData[currentDimension].startIndex;
        mainCam.enabled = true;
        done = true;
    }
}
