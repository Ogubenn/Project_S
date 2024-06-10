using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawn : MonoBehaviour
{
    [SerializeField] GameObject batteryPrefabs;
    public List<Transform> TransformList;

    private void Start()
    {
        SpawnBattery();
    }

    public void SpawnBattery()
    {
        int a = 0;
        while (a < TransformList.Count)
        {
            Instantiate(batteryPrefabs, TransformList[a].position, Quaternion.identity);
            a++;
        }
        Debug.Log("Bataryalar Spawnlandý");
    }
}
