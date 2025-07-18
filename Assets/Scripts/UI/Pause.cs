using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private AudioClip ClickSound;

    [SerializeField]
    private AudioClip buttonClickSound;

    private void Awake()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void PauseGame()
    {
        if (!pausePanel.activeInHierarchy)
        {
            AudioManager.Instance.PlaySound(ClickSound);
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            AudioManager.Instance.PlaySound(ClickSound);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void ResumeGame()
    {
        AudioManager.Instance.PlaySound(buttonClickSound);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
