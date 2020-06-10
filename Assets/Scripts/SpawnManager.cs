using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> chestSpawnPoints;
    
    [SerializeField]
    private GameObject chest;
    
    void Start()
    {
        SpawnChests();
    }
    private void SpawnChests()
    {
        foreach (GameObject point in chestSpawnPoints)
        {

            Instantiate(chest, point.transform.position, Quaternion.identity);
            
        }
    }

    
}
