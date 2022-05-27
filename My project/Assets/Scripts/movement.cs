using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed, jumpForce;
    void Start()
    {
        
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, 0f);
    }
}
