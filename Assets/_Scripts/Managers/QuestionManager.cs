using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject questioCanvas;
    public GameObject btnPrefab;
    public Transform btnTarget;
    public TextMeshProUGUI txt_titel;
    public TextMeshProUGUI txt_question;

    private List<GameObject> spawned = new List<GameObject>();
    public Question currentQuestion;
    public CameraManager cameraManager;

    public void openQuestion()
    {
        questioCanvas.SetActive(true);

        while(spawned.Count < currentQuestion.answers.Count)
        {
            GameObject btn = Instantiate(btnPrefab);
            btn.transform.SetParent(btnTarget, false);
            spawned.Add(btn);
            int temp = spawned.Count - 1;
            spawned[temp].GetComponent<Button>().onClick.AddListener(() => this.answerMultipleChoice(temp));
        }

        while(spawned.Count > currentQuestion.answers.Count)
        {
            GameObject des = spawned[spawned.Count - 1];
            spawned.Remove(spawned[spawned.Count - 1]);
            Destroy(des);
        }

        for (int i = 0; i < currentQuestion.answers.Count; i++)
        {
            spawned[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i].answers;
        }

        txt_titel.text = currentQuestion.titel;
        txt_question.text = currentQuestion.question;
    }

    public void answerMultipleChoice(int answer)
    {
        for (int i = 0; i < currentQuestion.answers.Count; i++)
        {
            currentQuestion.answers[i].selected = false;
        }
        currentQuestion.answers[answer].selected = true;
        currentQuestion.target.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void exitQuestion()
    {
        if (cameraManager.done)
        {
            StartCoroutine(cameraManager.MoveCamToObject(cameraManager.currentWaypoint.waypointTransform, true, true));
        }
        cameraManager.atObject = false;
        questioCanvas.SetActive(false);
    }
}
