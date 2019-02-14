using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pickle : MonoBehaviour
{
    private static SpriteRenderer _sr;

    private void Start()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PowerUp._PU.Pickles();
        _sr.enabled = false;
    }

    public static void Enable()
    {
        _sr.enabled = true;
    }
}
