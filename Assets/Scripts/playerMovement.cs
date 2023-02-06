using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            animator.SetBool("isJumping", true);
        }

        if(Input.GetKey(KeyCode.D))
        {
            characterScale.x = 0.65f;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if(isGrounded())
                animator.SetBool("isRunning", true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            characterScale.x = -0.65f;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if(isGrounded())
                animator.SetBool("isRunning", true);
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {   
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isRunning", false);
        }

        transform.localScale = characterScale;
        
        if(isGrounded())
            animator.SetBool("isJumping", false);
        else {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }

    // Checks if the player is grounded with raycast box collider   
    private bool isGrounded() 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
