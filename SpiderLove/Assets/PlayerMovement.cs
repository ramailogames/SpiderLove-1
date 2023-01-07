using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    [Header("Components")]
    public Animator anim;
    private Rigidbody2D rb;
 
    [Header("Movement")]
    public float dashSpeed;
    public float launchXSpeed;
    public float launchYSpeed;
    public float wallSlideSpeed;
    public float gravityScale;

    [Header("Properties")]
    bool isFacingRight = true;
    int facingDirection = 1;
    bool islaunching = false;
    int horizontalMovementDirection = 1;

    [Header("CheckSurroundings")]
    public Transform checkGroundPos;
    public Transform checkWallPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {


                if (Input.mousePosition.x < Screen.width / 2)
                {
                    //left
                    FlipLeft();
                    Dash();


                }

                if (Input.mousePosition.x > Screen.width / 2)
                {
                    //right
                    FlipRight();
                    Dash();

                }

            }
            // Dash();
        }

     

        CheckSurroundings();
    }

    private void CheckFlip()
    {
        if (isFacingRight && horizontalMovementDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && horizontalMovementDirection > 0)
        {
            Flip();
        }
    }

    public void Dash()
    {
      
        rb.velocity = new Vector2(horizontalMovementDirection * dashSpeed, 0);
    }

    public void Launch()
    {
        StartCoroutine(Enum_Launch());
    }

    IEnumerator Enum_Launch()
    {
        if (islaunching)
        {
            yield break;
        }
        Debug.Log("Launching");
        islaunching = true;
        
        yield return new WaitForSeconds(.05f);

        rb.velocity = new Vector2(-horizontalMovementDirection * launchXSpeed, launchYSpeed);
        //horizontalMovementDirection *= -1;
       //anim.SetBool("inAir", true);
        yield return new WaitForSeconds(.5f);

        islaunching = false;
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        horizontalMovementDirection *= -1;
        transform.Rotate(0f, 180.0f, 0f);
    }

    void FlipLeft()
    {
        horizontalMovementDirection = -1;
        isFacingRight = false;
        transform.rotation = Quaternion.Euler(0, 180.0f,0);
    }

    void FlipRight()
    {
        horizontalMovementDirection = 1;
        isFacingRight = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void CheckSurroundings()
    {
        bool checkGround = Physics2D.OverlapCircle(checkGroundPos.position, checkRadius, whatIsGround);
        bool checkWall = Physics2D.OverlapCircle(checkWallPos.position, checkRadius, whatIsWall);

        if (checkGround)
        {
            anim.SetBool("inAir", false);
        }
        else
        {
            anim.SetBool("inAir", true);
        }

        if (checkWall)
        {
            anim.SetBool("wallSliding", true);
            rb.gravityScale = wallSlideSpeed;
        }
        else
        {
            anim.SetBool("wallSliding", false);
            rb.gravityScale = gravityScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGroundPos.position, checkRadius);
        Gizmos.DrawWireSphere(checkWallPos.position, checkRadius);
    }

}
