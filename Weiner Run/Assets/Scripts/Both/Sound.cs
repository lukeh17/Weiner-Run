﻿using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string ClipName;

    public AudioClip clip;

    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}

