using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameController.instance.playerDied ();
            Destroy(other.gameObject);
            return;
	
			
		}//end if 
		else 
		{
			Destroy (other.gameObject);
		}//end else

	}//end trigger

}//end destroyer
