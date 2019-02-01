using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class ShowCustomization : MonoBehaviour
{

    public Object SpaceWeiner;
    public Object Weiner;
    public Object SpanishWeiner;
    public Object BikiniWeiner;
    public float x;
    public float y;

    private void Awake()
    {
        int index = PlayerPrefs.GetInt("Character", 0);
        
        switch(index)
        {          
            case 0: 
                Instantiate(Weiner, new Vector3(x, y, 6.842743f), Quaternion.Euler(0, 0, 0));
                
            break;
            
            case 1: 
                Instantiate(SpaceWeiner, new Vector3(x, y, 6.842743f), Quaternion.Euler(0, 0, 0));
                
            break;
            
            case 2: 
                Instantiate(SpanishWeiner, new Vector3(x, y, 6.842743f), Quaternion.Euler(0, 0, 0));
               
            break;
            
            case 3: 
                Instantiate(BikiniWeiner, new Vector3(x, y, 6.842743f), Quaternion.Euler(0, 0, 0));
                
            break;
        }
        
    }
  
}
