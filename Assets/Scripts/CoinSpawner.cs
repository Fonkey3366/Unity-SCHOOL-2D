using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;

    public int amount;

    private int spawnthingy;


    public Transform[] spawnpoints;

    private void Update()
    {
        while (spawnthingy < amount)
        {
            spawnthingy++;
            Instantiate(CoinPrefab, spawnpoints[Random.Range(0, spawnpoints.Length)].position, Quaternion.identity);
        }
    }
}
