using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    private int levelUnlocked;

    [SerializeField]
    private AudioClip buttonClickSound;
    private void Start()
    {
        levelUnlocked = SceneManager.GetActiveScene().buildIndex;
    }
    public void NextLevel()
    {
        AudioManager.Instance.PlaySound(buttonClickSound);
        PlayerPrefs.SetInt("LevelUnlocked", levelUnlocked);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
