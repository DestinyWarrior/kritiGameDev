using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField] float jump_vel = 7f;
   
    private float _currentHorizontalSpeed, _currentVerticalSpeed;
    [SerializeField] private float _acceleration = 90;
    [SerializeField] private float _moveClamp = 13;
    [SerializeField] private float _deAcceleration = 60f;
    public  float boost = 20f;
    [SerializeField] private float deboost = 9f;
    [SerializeField] private float generationTimefactor = 0.5f; //time factor to regain boost
    public float boostAcceleration = 180f;
    public float maxBoost=15f;

    public LayerMask jumpableGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        maxBoost = boost;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boost"))
        {
            boost = maxBoost;
            Destroy(collision.gameObject);

        }
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float b = Input.GetAxisRaw("Boost");
        if (boost < maxBoost)
        {
            boost += generationTimefactor * Time.deltaTime;
        }
        if (x!=0)
        {
            if (b != 0)
            {
                _currentHorizontalSpeed += x * boost;
                // Set horizontal move speed
                _currentHorizontalSpeed += x * boostAcceleration * Time.deltaTime;

                 float tempboost=boost - deboost* Time.deltaTime;

                if (tempboost > 0.09f)
                {
                    boost = tempboost;
                }
                // clamped by max frame movement
                _currentHorizontalSpeed = Mathf.Clamp(_currentHorizontalSpeed, -_moveClamp-boost, _moveClamp+boost);
            }
            else
            {
                // Set horizontal move speed
                _currentHorizontalSpeed += x * _acceleration * Time.deltaTime;

                // clamped by max frame movement
                _currentHorizontalSpeed = Mathf.Clamp(_currentHorizontalSpeed, -_moveClamp, _moveClamp); //restrict to moveClamp speed
            }
        }
        else
        {
            // No input. Let's slow the character down
            _currentHorizontalSpeed = Mathf.MoveTowards(_currentHorizontalSpeed, 0, _deAcceleration * Time.deltaTime);
        }


        rb.velocity = new Vector2(_currentHorizontalSpeed, rb.velocity.y);
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(0, jump_vel);
            }
        }
     /*   GatherInput();
        CalculateWalk();*/
    }
   


    /* #region Gather Input

     private void GatherInput()
     {

         bool jumpdown = Input.GetButtonDown("Jump");
         bool jumpup = Input.GetButtonUp("Jump");
         float hrztl = Input.GetAxisRaw("Horizontal");

         if (jumpdown)
         {
             _lastJumpPressed = Time.time;
         }
     }

     #endregion

     #region Walk

     [Header("WALKING")][SerializeField] private float _acceleration = 90;
     [SerializeField] private float _moveClamp = 13;
     [SerializeField] private float _deAcceleration = 60f;
     [SerializeField] private float _apexBonus = 2;

     private void CalculateWalk()
     {
         if (hrztl != 0)
         {
             // Set horizontal move speed
             _currentHorizontalSpeed += hrztl * _acceleration * Time.deltaTime;

             // clamped by max frame movement
             _currentHorizontalSpeed = Mathf.Clamp(_currentHorizontalSpeed, -_moveClamp, _moveClamp);

             // Apply bonus at the apex of a jump
             *//*var apexBonus = Mathf.Sign(Input.X) * _apexBonus * _apexPoint;*/
    /* _currentHorizontalSpeed += apexBonus * Time.deltaTime;*//*
 }
 else
 {
     // No input. Let's slow the character down
     _currentHorizontalSpeed = Mathf.MoveTowards(_currentHorizontalSpeed, 0, _deAcceleration * Time.deltaTime);
 }
 rb.velocity = new Vector2(_currentHorizontalSpeed, 0 );

}

#endregion
*/

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
