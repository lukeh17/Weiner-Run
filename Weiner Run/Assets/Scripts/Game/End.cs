using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InGame._IG.GameOver();
            Destroy(other.gameObject);
        } 
        else 
        {
            Destroy (other.gameObject);
        }
        Destroy(other.gameObject);
    }
}
