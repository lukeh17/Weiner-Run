using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupPower : MonoBehaviour {

    public Renderer ketchup;

    void Start()
    {
        ketchup = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(PowerUp());
            ketchup.enabled = false;
            GameController.instance.ShowSpeedMarks();
        } 
    }

    IEnumerator PowerUp()
    {
        Time.timeScale = 1f;
        Player.moveSpeed = 13f;
        yield return new WaitForSecondsRealtime(2);
        Player.moveSpeed = 11;
        
        StopCoroutine(PowerUp());
    }

}
