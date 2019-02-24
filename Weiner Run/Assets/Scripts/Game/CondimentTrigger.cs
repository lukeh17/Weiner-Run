using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        gameObject.SetActive(false);
        PowerUp._PU.SetCondiment(name);
    }
}
