using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public float senstivity = 7f;

    public LayerMask jumpableGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * senstivity, rb.velocity.y);
        if (IsGrounded())
        {
            if(Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(0, 7);
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
