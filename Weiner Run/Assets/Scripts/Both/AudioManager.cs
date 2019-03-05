using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _AM;
    public Sound[] sounds;

    void Awake()
    {
        _AM = this;
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
        AudioListener.volume = PlayerPrefs.GetInt("Pause", 1) == 1 ? 1 : 0;
    }
	
	public void Play (string name)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.ClipName == name);
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

