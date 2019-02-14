using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    /*public float bgSpeed;
    public Renderer bgRend;
    public static bool Enabled = true;

    private void Start()
    {
        bgRend.sortingOrder = 10;
        Enabled = true;
    }

    private void Update()
    {
        if (Enabled == false) return;
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }*/
    
    public BoxCollider2D groundCollider;       
    private float groundHorizontalLength;       

    private void Awake ()
    {
        groundHorizontalLength = groundCollider.size.x;
    }

    
    private void Update()
    {
        //transform position never changes maybe change to camera position.
        if (transform.position.x < groundHorizontalLength)
        {
            RepositionBackground ();
        }
    }

    private void RepositionBackground()
    {
        //Debug.Log("Reposition");
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
