using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDiamond : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectSound;
    public float hoverSpeed;
    public float hoverHeight;

    private Vector3 startPos;

    private void Start()
    {
        hoverSpeed = 2f;
        hoverHeight = 0.05f;
        startPos = transform.position;
    }

    private void Update()
    {
        Hover();
    }

    private void Hover()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy"))
        {
            AudioManager.Instance.PlaySound(collectSound);
            collision.GetComponent<FireboyMovement>().AddGem();
            Destroy(gameObject);
        }
    }
}
