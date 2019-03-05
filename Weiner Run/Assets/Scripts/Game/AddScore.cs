using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
   //Activated when the weiner touches the grill.
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Player")) return;
      InGame._IG.PlayerScored();
      PowerUp._PU.ShowFire();
   }
}
