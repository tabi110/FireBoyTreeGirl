using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenWater : MonoBehaviour
{
    [SerializeField]
    private GameObject fireboy;
    [SerializeField]
    private GameObject treegirl;
    private Animator anim;

    [SerializeField]
    private AudioClip maleDeathSound;
    [SerializeField]
    private AudioClip femaleDeathSound;

    [SerializeField]
    private GameObject gameOverPanel;
    private bool isGameOver;

    [SerializeField]
    private AudioClip gameOverSound;

    [SerializeField]
    private AudioClip splashSound;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        isGameOver = false;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Treegirl"))
    //    {
    //        AudioManager.Instance.PlaySound(femaleDeathSound);
    //        AudioManager.Instance.PlaySound(splashSound);
    //        anim = collision.gameObject.GetComponent<Animator>();
    //        Debug.Log("Treegirl collided with green water");
    //        anim.SetTrigger("die");
    //        isGameOver = true;
    //        StartCoroutine(GameOver());
    //        collision.gameObject.GetComponent<TreegirlMovement>().enabled = false;
    //        fireboy.GetComponent<FireboyMovement>().enabled = false;

    //    }
    //    else if (collision.gameObject.CompareTag("Fireboy"))
    //    {
    //        AudioManager.Instance.PlaySound(maleDeathSound);
    //        AudioManager.Instance.PlaySound(splashSound);
    //        anim = collision.gameObject.GetComponent<Animator>();
    //        Debug.Log("Fireboy collided with green water");
    //        anim.SetTrigger("die");
    //        isGameOver = true;
    //        StartCoroutine(GameOver());
    //        collision.gameObject.GetComponent<FireboyMovement>().enabled = false;
    //        treegirl.GetComponent<TreegirlMovement>().enabled = false;

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Treegirl"))
        {
            AudioManager.Instance.PlaySound(femaleDeathSound);
            AudioManager.Instance.PlaySound(splashSound);
            anim = collision.gameObject.GetComponent<Animator>();
            Debug.Log("Treegirl collided with green water");
            anim.SetTrigger("die");
            isGameOver = true;
            StartCoroutine(GameOver());
            collision.gameObject.GetComponent<TreegirlMovement>().enabled = false;
            fireboy.GetComponent<FireboyMovement>().enabled = false;

        }
        else if (collision.gameObject.CompareTag("Fireboy"))
        {
            AudioManager.Instance.PlaySound(maleDeathSound);
            AudioManager.Instance.PlaySound(splashSound);
            anim = collision.gameObject.GetComponent<Animator>();
            if(anim == null)
            {
                Debug.Log("empty");
            }
            Debug.Log("Fireboy collided with green water");
            anim.SetTrigger("die");
            isGameOver = true;
            StartCoroutine(GameOver());
            collision.gameObject.GetComponent<FireboyMovement>().enabled = false;
            treegirl.GetComponent<TreegirlMovement>().enabled = false;

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
