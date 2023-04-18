using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject escapePanel;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sensitivitySlider;

    [SerializeField] private TMP_Text textMusicValue;
    [SerializeField] private TMP_Text textSensitivityValue;

    public static float musicValue;
    public static float sensitivityValue;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            Yandex.ShowAdv();

        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1f);

        musicValue = PlayerPrefs.GetFloat("Music", 0.5f);
        sensitivityValue = PlayerPrefs.GetFloat("Sensitivity", 1f);
    }

    public void SetTime(float timeSeconds)
    {
        GameController.time = timeSeconds;
        SceneManager.LoadScene(1);
    }

    public void SetIndex(int index)
    {
        GameController.gameMode = index;
        SceneManager.LoadScene(1);
    }

    public void ShowSettingsPanel()
    {
        if(settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }

    public void ShowPlayPanel()
    {
        if(playPanel.activeSelf)
        {
            playPanel.SetActive(false);
        }
        else
        {
            playPanel.SetActive(true);
        }
    }

    public void ShowEscapePanel()
    {
        if(escapePanel.activeSelf)
        {
            escapePanel.SetActive(false);
        }
        else
        {
            escapePanel.SetActive(true);
        }
    }

    public void OnChangeMusic()
    {
        musicValue = musicSlider.value;
        int value = Mathf.FloorToInt(musicSlider.value * 100);
        PlayerPrefs.SetFloat("Music", musicValue);
        textMusicValue.text = value.ToString();
    }

    public void OnChangeSensitivity()
    {
        sensitivityValue = sensitivitySlider.value;
        int value = Mathf.FloorToInt(sensitivitySlider.value * 100);
        PlayerPrefs.SetFloat("Sensitivity", sensitivityValue);
        textSensitivityValue.text = value.ToString();
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Restart(int index)
    {
        SceneManager.LoadScene(index);

        if(GameController.gameMode == 1)
        {
            GameController.time = 30;
        }

        if(GameController.gameMode == 2)
        {
            GameController.time = 60;
        }

        if(GameController.gameMode == 3)
        {
            GameController.time = 150;
        }


    }
}