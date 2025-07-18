using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private AudioClip openSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireboy"))
        {
            AudioManager.Instance.PlaySound(openSound);
            anim.SetBool("open", true);
        }
        else
        {
            anim.SetBool("open", false);
        }
    }
}
