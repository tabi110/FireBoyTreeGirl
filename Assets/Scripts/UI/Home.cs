using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField]
    private AudioClip buttonClickSound;
    public void LevelSelect()
    {
        AudioManager.Instance.PlaySound(buttonClickSound);
        SceneManager.LoadScene("LevelSelect");
    }
}
