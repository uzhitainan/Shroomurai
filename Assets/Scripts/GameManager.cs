using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPause;
    public GameObject PauseWindow;

    void Start()
    {
        PauseWindow.gameObject.SetActive(false);
        isPause = false;
    }

    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                PauseWindow.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
            }
            else if (!isPause)
            {
                PauseWindow.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
}
