using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public float speed = 1.5f;
    private bool isMove = false;
    public float stopTime = 1;
    public float moveTime = 3;
    private float stopCounter;
    private float moveCounter;

    public Animator animator;

    private Rigidbody2D rb;

    private float moveDirection = -1;   // 1: right    -1: left

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stopCounter = stopTime;
        moveCounter = moveTime;
        
    }

    void FixedUpdate()
    {
        if(isMove == true)
        {
            rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        }
        if(isMove == false)
        {
            return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(stopCounter > 0)
        {
            stopCounter -= Time.deltaTime;
        }
        if(stopCounter < 0)
        {
            animator.SetBool("isMove", true);
            isMove = true;
            moveCounter -= Time.deltaTime;
            if(moveCounter < 0)
            {
                animator.SetBool("isMove", false);
                isMove = false;
                stopCounter = stopTime;
                moveCounter = moveTime;
                changeMoveDirection();
            }
        }
    }

    void changeMoveDirection()
    {
        moveDirection *= -1;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
