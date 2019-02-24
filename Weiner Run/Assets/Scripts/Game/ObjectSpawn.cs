using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    #region Variables
    public float spawnMinG = 1f;
    public float spawnMaxG = 2f;
    public float spawnMinC = 2f;
    public float spawnMaxC = 4f;
    public Transform grassSpawn;
    public Transform condimentSpawn;

    public static ObjectSpawn _os;
    #endregion

    private void Awake()
    {
        _os = this;
    }

    public void SpawnGrass()
    {
        ObjectPooler.pool_instance.SpawnFromPool("Grass", grassSpawn.position, Quaternion.identity);
        Invoke(nameof(SpawnGrass), Random.Range(spawnMinG, spawnMaxG));
    }

    public void SpawnCondiment()
    {
        ObjectPooler.pool_instance.SpawnFromPool(GetCondimentName(), condimentSpawn.position, Quaternion.identity);
        Invoke(nameof(SpawnCondiment), Random.Range(spawnMinC, spawnMaxC));
    }
    
    private static string GetCondimentName()
    {
        //CondimentTrigger._CondimentTrigger.condiment.enabled = true;
        
        var i = Random.Range(0, 5);
        switch (i)
        {
            case 0:
            case 1:
                return "Ketchup";
            case 2:
            case 3:
                return "Mustard";
            case 4:
                return "Pickle";
            default:
                return "Mustard";
        }
    }
}
