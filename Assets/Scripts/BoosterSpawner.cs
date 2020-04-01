using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    private float spawnSpeed = 10f;

    void Start()
    {
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        Vector3 Position = new Vector3(x, y, 0);
        Position.z = 0;
        Instantiate(GetComponent<BoosterItem>().getSpeedBooster(), Position, Quaternion.identity);
    }
}
