using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDRP : MonoBehaviour
{
    public void YesClick()
    {
        PlayerPrefs.SetInt("GDRP", 1);
    }
    
    public void NoClick()
    {
        PlayerPrefs.SetInt("GDRP", 0);
    }

    public void OpenLink()
    {
        Application.OpenURL("https://www.appodeal.com/privacy-policy");
    }
}
