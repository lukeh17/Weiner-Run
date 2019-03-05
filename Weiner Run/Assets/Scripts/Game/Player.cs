using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    public float jumpForce;
    public static float moveSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public GameObject mark;
    public GameObject fire;
    
    private Rigidbody2D rb;
    #endregion
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PowerUp._PU.SetObjects(mark, fire);
        CameraFollow.SetPlayer(gameObject);
        moveSpeed = 11;
    }
    
    void Update()
    {
        rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);

        if (!Input.GetMouseButtonDown(0) || !CheckGround()) return;
        rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        fire.SetActive(false);
        AudioManager._AM.Play("Jump");
    }

    private bool CheckGround()
    {
        return Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);   
    }
}
