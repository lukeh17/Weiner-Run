using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float yPos;
	public float xPos;

	public Transform Player;

	// Update is called once per frame
	void Update () {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x + xPos, yPos, -10);
        }
		
	}
}
