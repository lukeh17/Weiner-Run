using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _AM;
    public Sound[] sounds;

    private void Awake()
    {
        _AM = this;
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetInt("Pause", 1) == 1 ? 1 : 0;
    }
	
	public void Play (string name)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.ClipName == name);
        s.source.Play();
	}

    public void Mute()
    {
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

