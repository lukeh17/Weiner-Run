using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
		
	public static bool jump;
	public float jumpForce;
	public static float moveSpeed;
	public static Rigidbody2D rb;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	
	private bool onGround;	

	void Start()
	{
		moveSpeed = 11;
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetMouseButtonDown (0) && onGround) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			jump = true;
			FindObjectOfType<AudioManager>().Play("jump");
		}
		else
		{
			jump = false;
		}
	}
		
	public static void onDeath()
	{
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        SpawnScript.Enabled = false;
        moveSpeed = 0;

	}

	void OnCollisionExit2D (Collision2D col) 
	{
		if(col.collider.gameObject.tag == "Ground")
			GameController.instance.playerScored ();    
	}
		
}

		