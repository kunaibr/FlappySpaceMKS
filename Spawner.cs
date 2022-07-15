using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]

    public GameObject platform;
    [Header("Variables")]

    public float timeSpawn = 1.5f;
    public void StartSpawn()
    {
        InvokeRepeating("SpawnPlatform", timeSpawn * 2, timeSpawn);

    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnPlatform");
    }
    void SpawnPlatform()
    {
       float rnd = Random.Range(-2.5f, 2.5f);
        Vector2 localSpawn = new Vector2(transform.position.x,transform.position.y+rnd);

        Instantiate(platform, localSpawn, Quaternion.identity);
    }
}
