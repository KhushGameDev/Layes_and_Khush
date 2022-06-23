using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isFacingRight = true;
    public float coyoteTime = 0.2f;
    private bool doubleJump;
    public float coyoteTimeCounter;
    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private float jumpingPower = 16f;
    private float speed = 8f;
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.25f;
    private float dashingCooldown = 0.2f;
    private float horizontal;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator animator;


    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            animator.SetBool("IsJumping", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpBufferCounter = 0;
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                coyoteTimeCounter = 0;
                doubleJump = !doubleJump;
            }
        }
        if(rb.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
        }
        if(rb.velocity.y == 0)
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
        }
        if(rb.velocity.y > 0)
        {
            animator.SetBool("IsJumping", true);
        }
        if(rb.velocity.x > 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if(rb.velocity.x < 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if(rb.velocity.x == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
