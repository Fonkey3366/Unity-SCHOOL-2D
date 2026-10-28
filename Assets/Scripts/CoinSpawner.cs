using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;

    public int amount;

    private int spawnthingy;


    public Transform[] spawnpoints;

    public bool walkedtrough;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            walkedtrough = true;
        }
    }
    private void Update()
    {
        while (spawnthingy < amount && walkedtrough)
        {
            spawnthingy++;
            Instantiate(CoinPrefab, spawnpoints[Random.Range(0, spawnpoints.Length)].position, Quaternion.identity);
        }
    }
}
