using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachScript : MonoBehaviour
{
	public Animator anim;
	public static DetachScript Ds;
	private Rigidbody2D rb1;

	void Awake()
	{
		if (Ds == null)
		{
			Ds = this;
		}
	}

	void Start()
	{
		Transform[] children = GetComponentsInChildren<Transform>();
		rb1 = this.gameObject.GetComponent<Rigidbody2D>();
	}

	public void Detach()
	{
		anim.enabled = false;
		transform.parent = null;
		
		rb1.bodyType = RigidbodyType2D.Dynamic;
		rb1.AddForce(transform.up * 5);
		rb1.gravityScale = 1f;
		
		foreach (Transform child in transform)
		{
			Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
			rb.bodyType = RigidbodyType2D.Dynamic;
			rb.AddForce(transform.up * 5);
			rb.AddForce(transform.forward * 1);
			rb.AddTorque(4);
			rb.gravityScale = 1f;
		}
	}
}

