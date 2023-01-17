using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    

    [Header("Components")]
    public Animator anim;
    public SpriteRenderer sr;
    private Rigidbody2D rb;
 
    [Header("Movement")]
    public float dashSpeed;
    public float launchXSpeed;
    public float launchXWallSpeed;
    public float launchYSpeed;
    public float launchYWallSpeed;
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
    bool checkWall;
    bool isTouchingScreen = false;
    [HideInInspector] public bool canWallJump = false;
    bool isWallJumping = false;

    [Header("Character")]
    public Sprite[] charSprites;
    public GameObject hat,ear,nose;

    int charInt;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //charInt = PlayerPrefs.GetInt("charInt");
        SelectCharacter(SaveSettings.characterInt);
        Debug.Log(SaveSettings.characterInt);

        switch (SaveSettings.characterInt)
        {

            case 0:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 1:
                hat.SetActive(false);
                ear.SetActive(true);
                nose.SetActive(false);
                break;
            case 2:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(true);
                break;
            case 3:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 4:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 5:
                hat.SetActive(true);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
        }

    }
    private void OnEnable()
    {
       
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            isTouchingScreen = true;
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    //left
                    FlipLeft();
                    if (checkWall)
                    {
                        return;
                    }

                    Dash();


                }

                if (touch.position.x > Screen.width / 2)
                {
                    //right
                    FlipRight();
                    if (checkWall)
                    {
                        return;
                    }
                    Dash();

                }
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                isTouchingScreen = true;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isTouchingScreen = false;

                if (canWallJump)
                {
                    Debug.Log("wall jumping");
                    WallDash();
                }
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Pointer over ui");
                return;
            }
            isTouchingScreen = true;

                if (Input.mousePosition.x < Screen.width / 2)
                {
                    //left
                    FlipLeft();
                    if (checkWall)
                    {
                        return;
                    }
                   
                    Dash();


                }

                if (Input.mousePosition.x > Screen.width / 2)
                {
                    //right
                    FlipRight();
                    if (checkWall)
                    {
                        return;
                    }
                    Dash();

                }

        }

       
        
        
        if(Input.GetMouseButtonUp(0))
        {
            isTouchingScreen = false;

            if (canWallJump)
            {
                Debug.Log("wall jumping");
                WallDash();
            }

           
        }
            // Dash();
      

     

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

    public void WallDash()
    {
        StartCoroutine(EnumWallDash());
       
    }

    IEnumerator EnumWallDash()
    {
        isWallJumping = true;
        rb.velocity = new Vector2(-horizontalMovementDirection * launchXWallSpeed, launchYWallSpeed);
        horizontalMovementDirection *= -1;
        int index = Random.Range(1, 3);
        AudioManagerCS.instance.Play("yewhoo" + index);
        yield return new WaitForSeconds(0.5f);
        canWallJump = false;
        isWallJumping = false;
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
        horizontalMovementDirection *= -1;
       
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
        checkWall = Physics2D.OverlapCircle(checkWallPos.position, checkRadius, whatIsWall);

        if (checkGround)
        {
            anim.SetBool("inAir", false);
            return;
        }
        else
        {
            anim.SetBool("inAir", true);
        }

        if (checkWall)
        {
            if (!isTouchingScreen && !canWallJump && !isWallJumping)
            {
                Launch();
                return;
            }
            if (isTouchingScreen)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            anim.SetBool("wallSliding", true);
            anim.SetBool("inAir", false);


            //set sprite wall sliding
           
            
            rb.gravityScale = wallSlideSpeed;
            canWallJump = true;
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

    public void SelectCharacter(int currentCharInt)
    {
        sr.sprite = charSprites[currentCharInt];
    }

}
