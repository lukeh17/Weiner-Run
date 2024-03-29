﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        DetachScript._ds.Detach();
        Destroy(other.gameObject);
        BackgroundMove.Enabled = false;
        InGame._IG.GameOver();
    }
}
