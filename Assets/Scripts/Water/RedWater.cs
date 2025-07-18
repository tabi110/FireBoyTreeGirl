using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWater : MonoBehaviour
{
    [SerializeField]
    private GameObject fireboy;
    private Animator anim;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private GameObject gameOverPanel;
    private bool isGameOver;

    [SerializeField]
    private AudioClip gameOverSound;

    [SerializeField]
    private AudioClip splashSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Treegirl"))
        {
            AudioManager.Instance.PlaySound(deathSound);
            AudioManager.Instance.PlaySound(splashSound);
            anim = collision.gameObject.GetComponent<Animator>();
            anim.SetTrigger("die");
            isGameOver = true;
            StartCoroutine(GameOver());
            collision.gameObject.GetComponent<TreegirlMovement>().enabled = false;
            fireboy.GetComponent<FireboyMovement>().enabled = false;
        }

        if(collision.gameObject.CompareTag("Fireboy"))
        {
            AudioManager.Instance.PlaySound(splashSound);
        }
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
}
