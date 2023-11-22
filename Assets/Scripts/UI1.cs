using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI1 : MonoBehaviour
{
    public GameObject panel;

    public void OnClick_Start()
    {
        CountDown.State = 1;
        panel.gameObject.SetActive(false);
    }

    public void OnClick_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
