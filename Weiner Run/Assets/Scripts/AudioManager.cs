using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Pause", 1) == 1)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
	
	
	public void Play (string name)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
	}

    public void mute()
    {
        // AudioListener.pause = !AudioListener.pause;
        if (PlayerPrefs.GetInt("Pause", 1) == 0)
        {
            PlayerPrefs.SetInt("Pause", 1);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Pause", 1) == 1)
        {
            PlayerPrefs.SetInt("Pause", 0);
            AudioListener.volume = 0;
        }
    }
}

