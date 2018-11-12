using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickleScript : MonoBehaviour {

    public Renderer pickle;

    void Start()
    {
        pickle = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           int p = PlayerPrefs.GetInt("Pickles");
            Debug.Log("Before add " + p);
            p += 1;
            PlayerPrefs.SetInt("Pickles", p);
            Debug.Log("After add " + PlayerPrefs.GetInt("Pickles"));
            pickle.enabled = false;
            GameController.instance.UpdatePickleCount();
        }
    }
}
