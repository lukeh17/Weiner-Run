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
    #endregion

    private void Start()
    {
        Invoke(nameof(SpawnGrass), Random.Range(1, 2));
        Invoke(nameof(SpawnCondiment), Random.Range(1, 3));
    }

    private void SpawnGrass()
    {
        ObjectPooler.pool_instance.SpawnFromPool("Grass", grassSpawn.position, Quaternion.identity);
        Invoke(nameof(SpawnGrass), Random.Range(spawnMinG, spawnMaxG));
    }

    private void SpawnCondiment()
    {
        ObjectPooler.pool_instance.SpawnFromPool(GetCondimentName(), condimentSpawn.position, Quaternion.identity);
        Invoke(nameof(SpawnCondiment), Random.Range(spawnMinC, spawnMaxC));
    }
    
    private static string GetCondimentName()
    {
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
