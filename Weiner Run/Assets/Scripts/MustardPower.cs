using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustardPower : MonoBehaviour {

    public Renderer mustard;

    void Start()
    {
        mustard = GetComponent<SpriteRenderer>();        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.instance.AddScore();
            mustard.enabled = false;

            GameController.instance.ShowPlus20();           
        }  
    }

}
