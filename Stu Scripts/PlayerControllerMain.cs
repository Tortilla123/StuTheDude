using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerMain : MonoBehaviour {
    //Game Starting variables
    Rigidbody2D stu;
    Animator myAnim;
    bool facingRight;
    bool TouchingIce = false;
    
    //movement variables
    public float maxSpeed;                //player max speed

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.8f;       //ground collider radius under player
    public LayerMask groundLayer;         
    public Transform groundCheck;         //Checks if grounded 
    public float jumpHeight;              //Player Jump Height

    //audio variables
    public AudioClip playerPickUpSound;
    public AudioClip playerHurt;
    AudioSource playerAS;

    //projectiles variables
    public Transform laserStart;
    public GameObject laser;
    public float fireRate;
    public float nextFire;

    public int stageLose;
    public int stageWin;

    // Use this for initialization
    void Start()
    {
        stu = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;

        //Initiate Audio Source
        playerAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_STANDALONE || WEBPLAYER
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            stu.velocity = new Vector2(stu.velocity.x, jumpHeight);
        }

        Move(Input.GetAxisRaw("Horizontal"));
#endif

    }

    void FixedUpdate()
    {
        //check if Stu is grounded, if not then Stu is falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        //myAnim.SetFloat("speed", Mathf.Abs(move));
        
        /*if (Input.GetAxisRaw("Fire1") > 0)
            fireLaser();*/
    }

    /*void fireLaser()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(laser, laserStart.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else
            {
                Instantiate(laser, laserStart.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }*/

    public void Move(float moveInput)
    {
        myAnim.SetFloat("speed", Mathf.Abs(moveInput));
        myAnim.SetFloat("verticalSpeed", stu.velocity.y);

        //facing left and right
        if ( moveInput > 0 && !facingRight)
        {
            flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            flip();
        }

        //touching ice
        if (TouchingIce && grounded)
        {
            stu.AddForce(new Vector2(moveInput * maxSpeed * 0.1f, stu.velocity.y));
        }
        else
        {
            stu.velocity = new Vector2(moveInput * maxSpeed, stu.velocity.y);
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            stu.velocity = new Vector2(stu.velocity.x, jumpHeight);
        }
    }

    //Handles character flip back and forth
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            playerAS.clip = playerPickUpSound;
            playerAS.Play();
        }
        if (other.gameObject.CompareTag("Meteor"))
        {
            playerAS.clip = playerHurt;
            playerAS.Play();
        }

        if (other.gameObject.CompareTag("DeadZone"))
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(stageLose);
        }
        if (other.gameObject.CompareTag("WinZone"))
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(stageWin);
        }
               
    }

    //handles player movement on moving platforms
   private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.CompareTag("MovingPlatform"))
        {
            transform.parent = other.transform;

        }
        if (other.gameObject.tag == "IceFloor")
        {
            TouchingIce = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "IceFloor")
        {
            TouchingIce = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("MovingPlatform")) 
        {
            transform.parent = null;
        }
        if (other.gameObject.tag == "IceFloor")
        {
            TouchingIce = false;
        }

    }
   
}

