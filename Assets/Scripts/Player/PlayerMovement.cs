using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Paramenters")]
    [SerializeField] private float playerSpeed;

    private Rigidbody2D body;
    private Animator anim;

    private bool isFacingRight = true;
    private bool isGrounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerRun();
        PlayerAnimations();

        if(Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            PlayerJump();
        }

        if(Input.GetAxis("Horizontal") > 0 && isFacingRight == false)
        {
            FlipPlayer();
        }
        else if(Input.GetAxis("Horizontal") < 0 && isFacingRight == true)
        {
            FlipPlayer();
        }
        
    }

    private void PlayerAnimations()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void PlayerJump()
    {
        body.velocity = new Vector2(body.velocity.x, playerSpeed);
        isGrounded = false;
    }
    
    private void PlayerRun()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, body.velocity.y);
    } 

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
