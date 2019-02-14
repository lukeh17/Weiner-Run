using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float yPos;
	public float xPos;

	private static Transform player;

	public static void SetPlayer(GameObject p)
	{
		player = p.transform;
	}
	
	void Update () 
	{
		try
		{
			transform.position = new Vector3(player.position.x + xPos, yPos, -10);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}	
	}
}
