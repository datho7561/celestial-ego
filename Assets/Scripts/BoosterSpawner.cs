using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    private float spawnSpeed = 20f;

    void Start()
    {
        InvokeRepeating("GenerateSpeed", 0, spawnSpeed);
        InvokeRepeating("GenerateImmunity", 0, spawnSpeed);
    }

    void GenerateSpeed()
    {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        Vector3 Position = new Vector3(x, y, 0);
        Position.z = 0;
        Instantiate(GetComponent<BoosterItem>().getSpeedBooster(), Position, Quaternion.identity);
    }

    void GenerateImmunity() {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        Vector3 Position = new Vector3(x, y, 0);
        Position.z = 0;
        Instantiate(GetComponent<BoosterItem>().getImmunityBooster(), Position, Quaternion.identity);
    }
}
