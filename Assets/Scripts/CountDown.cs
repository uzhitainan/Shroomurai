using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float timeNow = 0;
    public int countDown= 5;
    public Text m_text;
    public GameObject block;
    public static int State = 0;
    AudioSource m_audioSource;
    bool m_isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        m_text= GetComponent<Text>();
        m_audioSource= GetComponent<AudioSource>();
        State = 1;
        m_isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 1)
        {
            Debug.Log("why");
            if(!m_isPlaying)
            {
                m_audioSource.Play();
                m_isPlaying = true;
            }
            timeNow += Time.deltaTime;
            if (countDown >= 0)
            {
                m_text.text = countDown.ToString();
                countDown = 5 - Mathf.FloorToInt(timeNow);
            }
            else if (countDown < 0)
            {
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
                block.gameObject.SetActive(false);
            }
        }
    }
}
