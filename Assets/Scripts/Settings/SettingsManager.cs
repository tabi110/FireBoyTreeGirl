using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Image soundFillImage;
    public Image musicFillImage;

    private float soundVolume;
    private float musicVolume;

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private AudioClip settingsButton;

    private void Awake()
    {
        settingsPanel.SetActive(false);
    }

    private void Start()
    {
        // Load saved volumes or use default 1
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 1);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);

        UpdateSoundUI();
        UpdateMusicUI();
    }

    public void OnSoundButtonClicked()
    {
        AudioManager.Instance.ChangeSoundVolume(0.1f);
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 1);
        UpdateSoundUI();
    }

    public void OnMusicButtonClicked()
    {
        AudioManager.Instance.ChangeMusicVolume(0.1f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);
        UpdateMusicUI();
    }

    private void UpdateSoundUI()
    {
        soundFillImage.fillAmount = soundVolume;
    }

    private void UpdateMusicUI()
    {
        musicFillImage.fillAmount = musicVolume;
    }

    public void SettingsPopUp()
    {
        AudioManager.Instance.PlaySound(settingsButton);
        if(settingsPanel.activeInHierarchy)
        {
            settingsPanel.gameObject.SetActive(false);
        }
        else
        {
            settingsPanel.gameObject.SetActive(true);
        }
    }
}
