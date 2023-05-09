using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{
    public Text m_textVolume;
    public Text m_textTime;
    public Text m_textInput;
    public Text m_textToggle;
    public InputField m_inputField;
    public Image m_image;
    public Toggle m_toggleR;
    public Toggle m_toggleB;
    public Toggle m_toggleG;
    public Slider m_slider;
    float image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image += 0.5f * Time.deltaTime;
            m_image.fillAmount = image;
        m_textTime.text = "Time: " + Time.time.ToString("0.0");
    }

    public void OnSliderValueChanged()
    {
        m_textVolume.text = "Volume:¡@" +¡@m_slider.value;
        m_image.fillAmount= m_slider.value;
    }

    public void OnToggleValueChanged()
    {
        if (m_toggleR.isOn)
        {
            m_textToggle.color= Color.red;
            m_textToggle.text = "Toggle: Red";
        }
        else if (m_toggleB.isOn)
        {
            m_textToggle.color= Color.blue;
            m_textToggle.text = "Toggle: Blue";
        }
        else if(m_toggleG.isOn)
        {
            m_textToggle.color= Color.green;
            m_textToggle.text = "Toggle: Green";
        }
        //m_textToggle.text = "Toggle:" + m_toggle.isOn;
    }

    public void OnClickButton()
    {
        m_image.color = Color.red;
        m_textTime.color= Color.green;
    }

    public void OnInputFieldValueChanged()
    {
        m_textInput.color = Color.white;
        m_textInput.text = m_inputField.text;
    }

    public void OnInputFieldEndEdit()
    {
        m_textInput.color= Color.blue;
    }
}
