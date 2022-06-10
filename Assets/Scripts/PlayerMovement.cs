using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;

    public float walkSpeed = 30f;
    public float runSpeed = 37f;
    public float horizontalMove;

    private bool faceRight = true;

    public float jumpForce = 20f;
    private bool isGrounded;
    public Transform floorCheck;
    public float floorCheckRadius;
    public LayerMask whatIsFloor;

    private int extraJumps;
    public int extraJumpsValue;

    public GameObject dialoguePopup;

    private AudioSource footstep;
    public AudioSource jumpStep;
    public AudioSource pushingBox;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialoguePopup.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y + 1.5f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
        extraJumps = extraJumpsValue;
        
    }
    
    void FixedUpdate()
    {
        Movement();
        isGrounded = Physics2D.OverlapCircle(floorCheck.position, floorCheckRadius, whatIsFloor);
    }

    void Update()
    {
        animator.SetBool("Grounded", isGrounded);
        JumpMove();
        dialoguePopup.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y + 1.5f);
    }

    void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        footstep.pitch = 0.95f;
        rb.velocity = new Vector2(horizontalMove * walkSpeed * Time.deltaTime, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(horizontalMove * runSpeed * Time.deltaTime, rb.velocity.y);
            footstep.pitch = 2f;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (faceRight == false && horizontalMove > 0)
        {
            Facing();
        }
        else if (faceRight == true && horizontalMove < 0)
        {
            Facing();
        }
        animator.SetFloat("AirSpeedY", rb.velocity.y);
    }

    void JumpMove()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {

            animator.SetTrigger("IsJump");
            isGrounded = false;
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("IsJump");
        }
    }

    void Facing()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Box")
        {
            isGrounded = true;
        }
    }



    private void Footsteps()
    {
        footstep.Play();
    }

    private void Jumpstep()
    {
        jumpStep.Play();
    }

    private void PushingBox()
    {
        pushingBox.Play();
    }
    //public void OnLanding()
    //{
    //    animator.SetBool("IsJumping", false);
    //}




}
