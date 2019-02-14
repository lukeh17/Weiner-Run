using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject plus20;
    private GameObject marks;

    public static PowerUp _PU;

    private void Awake()
    {
        _PU = this;
    }

    public void SetMarks(GameObject m)
    {
        marks = m;
    }

    #region +20
    public void ShowPlus20()
    {
        StartCoroutine(Plus20());
        InGame._IG.score += 20;
        InGame._IG.UpdateText();
    }

    private IEnumerator Plus20()
    {
        plus20.SetActive(true);
        yield return new WaitForSeconds(1);
        plus20.SetActive(false);
        Mustard.Enable();
    }
    #endregion

    #region speed
    public void ShowSpeedMarks()
    {
        StartCoroutine(SpeedMarks());
    }

    private IEnumerator SpeedMarks()
    {
            marks.SetActive(true);
            Player.moveSpeed = 12;
            yield return new WaitForSeconds(2);
            Player.moveSpeed = 11;
            marks.SetActive(false);
            Ketchup.Enable();
    }
    #endregion

    #region pickles
    public void Pickles()
    {
        int p = PlayerPrefs.GetInt("Pickles", 0);
        p += 1;
        PlayerPrefs.SetInt("Pickles", p);
        InGame._IG.UpdateText();
        DisableEnablePickle();
    }

    private static IEnumerator DisableEnablePickle()
    {
        yield return new WaitForSeconds(3);
        Pickle.Enable();
    }
    
    #endregion
}
