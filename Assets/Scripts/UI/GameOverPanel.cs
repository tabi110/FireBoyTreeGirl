using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private AudioClip buttonClickSound;
    public void Retry()
    {
        AudioManager.Instance.PlaySound(buttonClickSound);
        Time.timeScale = 1f; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        AudioManager.Instance.PlaySound(buttonClickSound);
        SceneManager.LoadScene(0);
    }
}
