using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
