using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCustomization : MonoBehaviour
{
    #region Weiners
    public Object RegularWeiner;
    public Object SpaceWeiner;
    public Object HispanicWeiner;
    public Object FancyWeiner;
    #endregion
    
    public Vector3 startPos;
    private void Start()
    {
        InGame._IG.UpdateText();            
        int character = PlayerPrefs.GetInt("Weiner", 0);

        switch (character)
        {
            case 0:
                Instantiate(RegularWeiner, startPos, Quaternion.Euler(0, 0, 0)); 
                break;
            case 1:
                Instantiate(SpaceWeiner, startPos, Quaternion.Euler(0, 0, 0));
                break;
            case 2:
                Instantiate(HispanicWeiner, startPos, Quaternion.Euler(0, 0, 0));
                break;
            case 3:
                Instantiate(FancyWeiner, startPos, Quaternion.Euler(0, 0, 0));
                break;
        }  
    }
}
