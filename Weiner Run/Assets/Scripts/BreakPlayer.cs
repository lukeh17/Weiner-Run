using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlayer : MonoBehaviour {

    public bool collision;
    public float rayDistance;
    public RaycastHit2D hit;
    public float raycastMaxDistance;


    public float originOffset = 1f;
    private Explodable _explodable;

    void Start()
	{
        _explodable = GetComponent<Explodable>();
    }

    private RaycastHit2D checkRayCast(Vector2 direction)
    {
        float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

        Vector2 startingPos = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);

        //Debug.DrawRay(startingPos, direction, Color.magenta);
        return Physics2D.Raycast(startingPos, direction, raycastMaxDistance, 1 << LayerMask.NameToLayer("Ground"));
    }

    private void FixedUpdate()
    {
        RaycastCheckUpdate();
    }

    private bool RaycastCheckUpdate()
    {
        while (true)
        {
            Vector2 direction = new Vector2(1, 0);
            RaycastHit2D hit = checkRayCast(direction);

            if (hit.collider)
            {
               // Debug.Log("Hit Object " + hit.collider.name);
                PlayerExplode();

                return true;
            }
            else
            {
                return false;
            }

        }

    }


    public void PlayerExplode()
    {
        
      
        _explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        ef.doExplosion(transform.position);
        //Debug.Log("Should Explode");
        
        //GameController.instance.playerDied();

        return;
    }

}

