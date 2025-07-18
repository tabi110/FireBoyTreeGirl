using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public float tiltAmount = 15f;    // Maximum rotation (degrees)
    public float tiltSpeed = 5f;      // Speed of tilting

    private float targetZRotation = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy"))
        {
            Vector3 localPos = transform.InverseTransformPoint(collision.transform.position);

            if (localPos.x > 0)
                targetZRotation = -tiltAmount;   // Tilt right
            else
                targetZRotation = tiltAmount;    // Tilt left
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy"))
        {
            targetZRotation = 0f;    // Reset when player leaves
        }
    }

    private void Update()
    {
        float z = Mathf.LerpAngle(transform.eulerAngles.z, targetZRotation, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
