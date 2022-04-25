using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public int currentIndex;
    public Waypoint[] waypointPath;
    [SerializeField]
    private Camera mainCam;
    private IEnumerator running;
    public float time;
    public bool done = true, atObject;
    public Waypoint currentWaypoint;
    //TEMP MOVE TO BETTER PLACE
    public GameObject canvasMap;
    public GameObject btn_left, btn_right, btn_up, btn_down;

    private void Start()
    {
        mainCam = Camera.main;

        //Setup start postion waypoint 1
        currentWaypoint = getWaypointDate(currentIndex);
        mainCam.transform.position = currentWaypoint.waypointTransform.position;
        mainCam.transform.rotation = currentWaypoint.waypointTransform.rotation;

        setUIArrow();
    }

    public void setUIArrow()
    {
        if (currentWaypoint.targets.left)
            btn_left.SetActive(true);
        else
            btn_left.SetActive(false);

        if (currentWaypoint.targets.right)
            btn_right.SetActive(true);
        else
            btn_right.SetActive(false);


        if (currentWaypoint.targets.up)
            btn_up.SetActive(true);
        else
            btn_up.SetActive(false);

        if (currentWaypoint.targets.down)
            btn_down.SetActive(true);
        else
            btn_down.SetActive(false);
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
    }

    public Waypoint getWaypointDate(int index)
    {
        return waypointPath.FirstOrDefault(obj => obj.index == index);
    }

    public enum direction
    {
        left = 0,
        right = 1,
        up = 2,
        down = 3
    }

    public void moveDir(int number)
    {
        direction dir = (direction) number;

        switch (dir)
        {
            case direction.left:
                {
                    if (running != null || !waypointPath[currentIndex].targets.left)
                        return;
                    running = MoveCamToObject(waypointPath[currentIndex].targets.left);
                    StartCoroutine(running);
                    return;
                }
            case direction.right:
                {
                    if (running != null || !waypointPath[currentIndex].targets.right)
                        return;
                    running = MoveCamToObject(waypointPath[currentIndex].targets.right);
                    StartCoroutine(running);
                    return;
                }
            case direction.up:
                {
                    if (running != null || !waypointPath[currentIndex].targets.up)
                        return;
                    running = MoveCamToObject(waypointPath[currentIndex].targets.up);
                    StartCoroutine(running);
                    return;
                }
            case direction.down:
                {
                    if (running != null || !waypointPath[currentIndex].targets.down)
                        return;
                    running = MoveCamToObject(waypointPath[currentIndex].targets.down);
                    StartCoroutine(running);
                    return;
                }
        }
        return;
    }

    public void moveToIndex(int number)
    {
        currentWaypoint = getWaypointDate(number);
        if (running != null || !currentWaypoint.waypointTransform)
            return;
        mainCam.transform.position = currentWaypoint.waypointTransform.transform.position;
        mainCam.transform.rotation = currentWaypoint.waypointTransform.transform.rotation;
        setUIArrow();
    }

    public IEnumerator MoveCamToObject(Transform camPos, bool isQuestion = false, bool exitState = false)
    {
        done = false;
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
        if(waypointPath.FirstOrDefault(x => x.waypointTransform == camPos) != null)
            currentIndex = waypointPath.FirstOrDefault(x => x.waypointTransform == camPos).index;
            currentWaypoint = getWaypointDate(currentIndex);
        running = null;
        setUIArrow();
    }
}
