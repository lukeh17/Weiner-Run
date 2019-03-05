using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachScript : MonoBehaviour
{
	public Animator anim;
	public static DetachScript _ds;
	private Rigidbody2D[] _rigidbody2Ds;

	void Awake()
	{
		_ds = this;
	}

	void Start()
	{
		_rigidbody2Ds = GetComponentsInChildren<Rigidbody2D>();
	}

	public void Detach()
	{
		AudioManager._AM.Play("Explosion");
		anim.enabled = false;
		transform.parent = null;
		foreach (Rigidbody2D rb in _rigidbody2Ds)
		{			
			rb.bodyType = RigidbodyType2D.Dynamic;
			rb.AddForce(transform.up * Random.Range(200, 500));
			rb.AddTorque(Random.Range(10, 350));
			rb.gravityScale = 1f;
			rb.AddForce(transform.right * Random.Range(100, 300));
			Destroy(gameObject, 5);
		}
	}
}

