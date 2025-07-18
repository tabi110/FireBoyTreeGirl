using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWater : MonoBehaviour
{
    [SerializeField]
    private GameObject treegirl;
    private Animator anim;

    [SerializeField]
    private GameObject gameOverPanel;
    private bool isGameOver;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip gameOverSound;
    [SerializeField]
    private AudioClip splashSound;
    private void Awake()
    {
        isGameOver = false;
        gameOverPanel.SetActive(false);
    }

    IEnumerator GameOver()
    {
        if (isGameOver)
        {
            yield return new WaitForSeconds(1f);
            AudioManager.Instance.PlaySound(gameOverSound);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireboy"))
        {
            AudioManager.Instance.PlaySound(deathSound);
            AudioManager.Instance.PlaySound(splashSound);
            anim = collision.gameObject.GetComponent<Animator>();
            anim.SetTrigger("die");
            isGameOver = true;
            StartCoroutine(GameOver());
            collision.gameObject.GetComponent<FireboyMovement>().enabled = false;
            treegirl.GetComponent<TreegirlMovement>().enabled = false;

        }

        else if (collision.gameObject.CompareTag("Treegirl"))
        {
            AudioManager.Instance.PlaySound(splashSound);
        }
    }
}
