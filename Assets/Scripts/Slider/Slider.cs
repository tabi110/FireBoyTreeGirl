using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform leftPosition;
    public Transform rightPosition;
    public float moveSpeed = 2f;

    private bool isPressed = false;

    public void SetPressed(bool pressed)
    {
        isPressed = pressed;
    }

    private void Update()
    {
        if(isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPosition.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPosition.position, moveSpeed * Time.deltaTime);
        }
    }
}
