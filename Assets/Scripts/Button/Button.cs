using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Slider slider;
    private Vector3 originalPosition;
    public float pressedOffset = 0.15f;

    [SerializeField]
    private AudioClip doorOpenSound;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy") || collision.CompareTag("Treegirl"))
        {
            PressButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy") || collision.CompareTag("Treegirl"))
        {
            ReleaseButton();
        }
    }

    private void PressButton()
    {
        transform.position = new Vector3(originalPosition.x, originalPosition.y - pressedOffset, originalPosition.z);
        slider.SetPressed(true);
        AudioManager.Instance.PlaySound(doorOpenSound);
    }

    private void ReleaseButton()
    {
        transform.position = originalPosition;
        slider.SetPressed(false);
    }
}
