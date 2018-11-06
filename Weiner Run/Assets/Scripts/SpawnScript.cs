using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    private new static bool enabled = true;
    public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

    public static bool Enabled
    {
        get
        {
            return enabled;
        }

        set
        {
            enabled = value;
        }
    }

    // Use this for initialization
    void Start () {
		Spawn ();
	}
	
	void Spawn()
	{
		if (Enabled != false) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
			Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	
		}
	}
}
