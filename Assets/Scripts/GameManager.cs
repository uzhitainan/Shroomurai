using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Toggle Valoume;
    public Text m_textVolume;
    public Text Timecount;
    public bool isPause;
    public GameObject PauseWindow;
    public Image m_image;
    public Slider m_slider;

    void Start()
    {
        Timecount = GetComponent<Text>();
        PauseWindow.gameObject.SetActive(false);
        isPause = false;

    }

    void Update()
    {
        Pause();
        Timecount.text = "Time: " + Time.time.ToString("0.0");
    }

    public void Valome()
    {
        if (!Valoume.isOn)
            m_slider.value = 0;
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

    public void SliderChange()
    {
        m_textVolume.text = "Volume:¡@" + m_slider.value;
        m_image.fillAmount= m_slider.value;
    }
}
