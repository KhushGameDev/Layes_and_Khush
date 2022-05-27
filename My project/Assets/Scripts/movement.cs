using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float speed;
    public float jump;
    public LayerMask layerForJumping;
    public bool IsGrounded;
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
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            }   
        }
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

    }
}