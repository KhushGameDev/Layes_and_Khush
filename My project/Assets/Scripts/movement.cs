using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private int jumps;
    public int JumpAmount;
    public LayerMask layerForJumping;
    public bool isGrounded;
    public GameObject groundCheckPosition;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckPosition.transform.position, 0.01f, layerForJumping);
        if (collider.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (isGrounded)
        {
            jumps = JumpAmount;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumps--;
        }
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

    }
}