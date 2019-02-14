using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    public float TimeTillDistruct;

    private void Start()
    {
        Destroy(gameObject, TimeTillDistruct);
        Destroy(this, TimeTillDistruct);
    }
}
