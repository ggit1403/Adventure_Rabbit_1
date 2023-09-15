 using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed = 5f;
   public float jumpSpeed = 8f;
   private float direction = 0f;
   private Rigidbody2D player;

    public Animator animator;

   public Transform groundCheck;
   public float groundCheckRadius;
   public LayerMask groundLayer;
   private bool isTouchingGround;
   private bool facingRight=true;

    

    void Start()
   {
       player = GetComponent<Rigidbody2D>();
        
            
        
    }
   void Update()
   {
       isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
       direction = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(direction));

       if (direction > 0f)
       {
           player.velocity = new Vector2(direction * speed, player.velocity.y);
       }
       else if (direction < 0f)
       {
           player.velocity = new Vector2(direction * speed, player.velocity.y);
       }
       else
       {
           player.velocity = new Vector2(0, player.velocity.y);
       }

       if (Input.GetButtonDown("Jump") && isTouchingGround)
       {
           player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
       }
   }
    private void FixedUpdate()
   {
        if(!facingRight && direction > 0)
       {
           Flip();
       }else if(facingRight && direction < 0)
       {
           Flip();
       }
   }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

   void Flip()
   {
       facingRight = !facingRight;
       Vector2 currentScale = transform.localScale;
       currentScale.x *= -1;
       transform.localScale = currentScale;
   }
}
