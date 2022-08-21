using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    bool isGrounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        isGrounded = true;
    }
    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("Walking", Horizontal != 0.0f);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            Jump();
        }

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        

        Debug.DrawRay(transform.position, Vector3.down * 0.70f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {

        }

    }

    void Jump()
    {
        isGrounded = false;
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Suelo")
        {
            isGrounded = true;
        }
    }
}
