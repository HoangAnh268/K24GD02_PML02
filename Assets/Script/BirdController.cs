﻿using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public GameObject message;
    private bool isFlying = false;
    private int score;
    private bool isStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Ngăn chim rơi ngay từ đầu
        message.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (!isStarted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {               
                isStarted = true;
                GameManager.instance.isGameStarted = true;
                rb.gravityScale = 1.5f;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isFly", true);
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
        
        else if (isStarted)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isFly", true);
                isFlying = true;
                
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        isFlying = false;
        animator.SetBool("isFly", false);
        if (collision.gameObject.CompareTag("Ground"))
        {                    
            Debug.Log("Đã chạm đất");
        }
        GameManager.instance.GameOver();
    }
    
}
