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
  
    [SerializeField] private float deboost = 9f;
    [SerializeField] private float generationTimefactor = 0.5f; //time factor to regain boost
    public float boost = 20f;
    public float boostAcceleration = 180f;
    private float maxBoost=15f;
    public BoostBar boostcontrol;

    public LayerMask jumpableGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        maxBoost = boost;
        boostcontrol.SetMaxBoost(maxBoost);
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
        boostcontrol.SetBoost(boost);
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
   


 
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
