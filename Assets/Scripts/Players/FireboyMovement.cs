using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireboyMovement : MonoBehaviour
{

    private bool moveLeft, moveRight, jumpRequest;


    [SerializeField]
    private Collider2D fireboyCollider;
    [SerializeField]
    private Collider2D treegirlCollider;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;
    private Animator anim;
    private bool isGrounded;
    public int gemCount;

    [SerializeField]
    private Text gemCountText;

    [SerializeField]
    private AudioClip jumpSound;

    public bool reachedDoor;

    [SerializeField] 
    private Transform groundCheck; // Assign in Inspector
    [SerializeField] 
    private float RayLength = 0.01f; // Size of circle to check
    [SerializeField] 
    private LayerMask groundLayer;
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
    }
    //void Movement()
    //{
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (isGrounded)
    //        {
    //            anim.SetBool("run", true);
    //        }
    //        rb.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
    //        rb.linearVelocity = new Vector2(-(speed * Time.deltaTime), rb.linearVelocity.y);
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        if (isGrounded)
    //        {
    //            anim.SetBool("run", true);
    //        }
    //        rb.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
    }

    //void Update()
    //{
    //    Physics2D.IgnoreCollision(fireboyCollider, treegirlCollider, true);
    //    Movement();

    //    if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
    //    {
    //        isGrounded = false;
    //        Jump();
    //    }
    //}

    void Update()
    {
        Physics2D.IgnoreCollision(fireboyCollider, treegirlCollider, true);

        
        HandleMovement();

        if (jumpRequest && isGrounded)
        {
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
            rb.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (moveRight)
        {
            move = speed;
            rb.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        if (collision.gameObject.CompareTag("RedDoor"))
        {
            anim.SetBool("run", false);
            reachedDoor = true;
            gameObject.GetComponent<FireboyMovement>().enabled = false;
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
        moveRight    = false;
    }

    public void onJumpRequest()
    {
        jumpRequest = true;
    }

    
}
