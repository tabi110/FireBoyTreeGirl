using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreegirlMovement : MonoBehaviour
{

    private bool moveLeft, moveRight, jumpRequest;


    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;
    private bool isGrounded = true;
    public int gemCount;

    [SerializeField]
    private Text gemCountText;

    [SerializeField]
    private AudioClip jumpSound;

    public bool reachedDoor;
    private void Start()
    {
        reachedDoor = false;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
        gemCount = 0;
    }

    //void Movement()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        if (isGrounded)
    //        {
    //            anim.SetBool("run", true);
    //        }
    //        rb.transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
    //        rb.linearVelocity = new Vector2(-(speed * Time.deltaTime), rb.linearVelocity.y);
    //    }
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        if (isGrounded)
    //        {
    //            anim.SetBool("run", true);
    //        }
    //        rb.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    //        rb.linearVelocity = new Vector2(speed * Time.deltaTime, rb.linearVelocity.y);
    //    }
    //    else
    //    {
    //        anim.SetBool("run", false);
    //    }
    //}
    private void Jump()
    {

        AudioManager.Instance.PlaySound(jumpSound);
        isGrounded = false;
        anim.SetBool("grounded", false);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
    }

    //void Update()
    //{
    //    Movement();
    //    if (Input.GetKeyDown(KeyCode.W) && isGrounded)
    //    {
    //        Jump();
    //    }
    //}

    void Update()
    {
        //Physics2D.IgnoreCollision(fireboyCollider, treegirlCollider, true);

        HandleMovement();

        if (jumpRequest && isGrounded)
        {
            isGrounded = false;
            Jump();
            jumpRequest = false;
        }
    }

    void HandleMovement()
    {
        float move = 0f;

        if (moveLeft)
        {
            move = -speed;
            rb.transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
        }
        else if (moveRight)
        {
            move = speed;
            rb.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);
        anim.SetBool("run", move != 0 && isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("grounded", true);
        }
    }
    public void AddGem()
    {
        gemCount++;
        gemCountText.text = "X" + gemCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GreenDoor"))
        {
            anim.SetBool("run", false);
            reachedDoor = true;
            gameObject.GetComponent<TreegirlMovement>().enabled = false;
        }
    }

    public bool IsReachedDoor()
    {
        return reachedDoor;
    }

    public void OnLeftDown()
    {
        moveLeft = true;
    }

    public void OnLeftUp()
    {
        moveLeft = false;
    }

    public void OnRightDown()
    {
        moveRight = true;
    }

    public void OnRightUp()
    {
        moveRight = false;
    }

    public void onJumpRequest()
    {
        jumpRequest = true;
    }
}
