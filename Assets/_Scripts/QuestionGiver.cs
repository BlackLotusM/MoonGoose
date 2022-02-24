using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGiver : MonoBehaviour
{
    [Header("Question")]
    public Question question;
    public QuestionManager questionManager;

    [Header("Camera stuff")]
    public Transform camPos;
    [Header("Manager")]
    public CameraManager cameraManager;

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        for (int i = 0; i < question.answers.Count; i++)
        {
            question.answers[i].titel = "Antwoord: " + (1 + i);
        }
    }
#endif

    private void Start()
    {
        questionManager = FindObjectOfType<QuestionManager>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && cameraManager.done)
        {
            cameraManager.atObject = false;
            cameraManager.done = false;
            StartCoroutine(cameraManager.MoveCamToObject(cameraManager.currentWaypoint.waypointTransform, true, true));
        }
    }
    private void OnMouseDown()
    {
        if (cameraManager.done)
        {
            questionManager.currentQuestion = question;
            cameraManager.atObject = true;
            cameraManager.done = false;
            StartCoroutine(cameraManager.MoveCamToObject(camPos, true, false));
        }
    }
    
    public void sendQuestion()
    {
        questionManager.openQuestion();
    }

    public void sendExit()
    {
        questionManager.exitQuestion();
    }
}
