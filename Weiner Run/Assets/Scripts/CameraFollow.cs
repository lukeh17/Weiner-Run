using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float yPos;
	public float xPos;

	private Transform Player;

	void Start()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	void Update () 
	{
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x + xPos, yPos, -10);
        }
	}
}
