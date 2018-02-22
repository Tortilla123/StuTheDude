using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {

    Rigidbody2D stu;
    Animator anim;

    bool facingRight;

    public float maxSpeed;

    bool grounded = false;
    float groundCheckRadius = 0.8f;       //ground collider radius under player
    public LayerMask groundLayer;
    public Transform groundCheck;         //Checks if grounded 
    public float jumpHeight;


    // Use this for initialization
    void Start () {
        stu = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        //check if Stu is grounded, if not then Stu is falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("isGrounded", grounded);

        anim.SetFloat("verticalSpeed", stu.velocity.y);

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
    }
}
