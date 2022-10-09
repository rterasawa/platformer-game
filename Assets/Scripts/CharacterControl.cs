using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{

    public ParticleSystem Dust;

    public float speed;
    private float moveInput;
    public float jumpFactor;
    private Rigidbody2D rb;

    public Animator animator;
    private AudioSource footstep;

    private bool FacingRight = true;

    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJump;

    public int fish = 0;
    public Text NumberOfFish;

    public AudioSource getFish;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footstep = GetComponent<AudioSource>();
    }

    // Translate according to the controls pressed.

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, whatIsGround);

     
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            createDust();
            jumpTimeCounter = jumpTime;
            isJump = true;
            rb.velocity = Vector2.up * jumpFactor;

        }

        if (Input.GetKey(KeyCode.Space) && isJump == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpFactor;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJump = false;
        }

        if (isGrounded != true)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }


        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if(FacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(FacingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collectable")
        {
            getFish.Play();
            Destroy(collision.gameObject);
            fish += 1;
            NumberOfFish.text = fish.ToString();
        }
    }

    void Flip()
    {
        if (isGrounded == true) {
        createDust();
        }

        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Footstep()
    {
        footstep.Play();
    }

    void createDust()
    {
        Dust.Play();
    }
}
