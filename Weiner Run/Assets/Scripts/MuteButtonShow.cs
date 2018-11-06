using UnityEngine;

public class MuteButtonShow : MonoBehaviour {

    public GameObject Settings;

    public GameObject SoundOn;
    public GameObject SoundOff;

	void Start () {

        if (Settings.activeInHierarchy == true)
        {
            if (PlayerPrefs.GetInt("Pause") == 0)
            {
                SoundOff.SetActive(true);
                SoundOn.SetActive(false);

            }
            else
            {
                SoundOn.SetActive(true);
                SoundOff.SetActive(false);
            }

        }
	}
	
	
}
