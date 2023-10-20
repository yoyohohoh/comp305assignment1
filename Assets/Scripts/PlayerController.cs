using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // public variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    //show as "public" but is private actually
    //cannot access by other scripts
    //but can be changed in the inspector
    
    // private variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private bool isCrouched = false;
    public GameObject heartPrefab;
    private LifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        lifeSystem = GameObject.Find("LifeSystem").GetComponent<LifeSystem>();

    }

    // Physics
    private void FixedUpdate()
    {
        //Debug.Log("Fixed Update Time: " + Time.deltaTime);
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump
        if ( isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }
        

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Check if the sprite needs to be flipped
        if((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }

        // conmmunicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        
        //Debug.Log(rBody.velocity.y);
    }

    private void Update()
    {
        Crouch();
        {
            anim.SetBool("isCrouched", isCrouched);
        }
    }

    private bool GroundCheck()
    {
        //Debug.Log("Ground Check");
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    //if "LuckyBox" is destroyed, then an obejct with name "heart" is created
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BreakBox"))
        {
            Debug.Log("Heart ");
            GameObject heart = Instantiate(heartPrefab, this.transform.position, Quaternion.identity);
            heart.transform.position = new Vector3(3.55f, 10.00f, 0f);
            heart.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        if(other.gameObject.CompareTag("Heart"))
        {
            lifeSystem.ResetLife();
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCrouched = true;
            Debug.Log("Crouching = " + isCrouched);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouched = false;
            Debug.Log("Crouching = " + isCrouched);
        }


    }


}
