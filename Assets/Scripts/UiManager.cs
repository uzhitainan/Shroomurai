using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject PauseWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        PauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
