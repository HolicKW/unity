using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] Animator myAnimator;
    [SerializeField] float Gravity;

    [SerializeField] bool isAlive = true;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform GunTransform;
    CapsuleCollider2D myBodyColider;
    BoxCollider2D myFeetColider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyColider = GetComponent<CapsuleCollider2D>();
        myFeetColider = GetComponent<BoxCollider2D>();
        Gravity = rb.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bulletPrefab, GunTransform.position, transform.rotation);
    }
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();

        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!isAlive){ return;}
        if (!myFeetColider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);

        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
            GunTransform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }

    }

    void ClimbLadder()
    {
        if (!myFeetColider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = Gravity;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 ClimbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = ClimbVelocity;
        rb.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);

    }

    void Die()
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Enemies","Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            rb.velocity += deathKick;
            
        }
    }
}
