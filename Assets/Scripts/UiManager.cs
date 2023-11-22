using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject PauseWindow;
    public GameObject Vpanel;
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 0;
        CountDown.State = 1;
    }

    public void Vpanelopen()
    {
        Vpanel.gameObject.SetActive(true);
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
        Vpanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
