using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public GameObject questioCanvas;
    public GameObject btnPrefab;
    public Transform btnTarget;
    public TextMeshProUGUI txt_titel;
    public TextMeshProUGUI txt_question;

    private List<GameObject> spawned = new List<GameObject>();
    public Question currentQuestion;
    public void openQuestion()
    {
        questioCanvas.SetActive(true);

        while(spawned.Count < currentQuestion.answers.Count)
        {
            GameObject btn = Instantiate(btnPrefab);
            btn.transform.SetParent(btnTarget, false);
            spawned.Add(btn);
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

    public void exitQuestion()
    {
        questioCanvas.SetActive(false);
    }
}
