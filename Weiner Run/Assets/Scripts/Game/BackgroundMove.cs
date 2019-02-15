using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;
    public static bool Enabled = true;

    private void Start()
    {
        Enabled = true;
    }

    private void Update()
    {
        if (Enabled == false) return;
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
    
}
