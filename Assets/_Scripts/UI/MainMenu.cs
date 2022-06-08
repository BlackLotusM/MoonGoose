using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField klasField;
    public GameObject stella;
    public Sprite stellaSprite;
    public GameObject dad;
    public Sprite dadSprite;
    public PersonSO leerlingOBJ;
    public bool chosen = false;
    public Sprite current;
    public TextMeshProUGUI notAllfield;
    public Image sourceStella;
    public Image sourceDad;
    public Sprite stellaChoose;
    public Sprite dadChoose;
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChooseStella()
    {
        chosen = true;
        stella.SetActive(true);
        dad.SetActive(false);
        sourceDad.sprite = dadSprite;
        sourceStella.sprite = stellaChoose;
        current = stellaSprite;
    }

    public void ChooseDad()
    {
        chosen = true;
        stella.SetActive(false);
        dad.SetActive(true);
        sourceDad.sprite = dadChoose;
        sourceStella.sprite = stellaSprite;
        current = dadSprite;
    }

    public void StartGame(int sceneIndex)
    {
        if (nameField.text != "" && klasField.text != "" && chosen)
        {
            leerlingOBJ.characterName = nameField.text;
            leerlingOBJ.profilePic = current;
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Color col = notAllfield.color;
            col.a = 1;
            notAllfield.color = col;
        }
    }
}
