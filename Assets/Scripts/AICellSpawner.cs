using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICellSpawner : MonoBehaviour
{
    public float SpawnSpeed;
    public GameObject AICell;

    void Start() {
        for (int i = 0; i < 10; i++)
            Generate();
        InvokeRepeating("Generate", 0, SpawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        Vector3 Position = new Vector3(x, y, 0);
        Position.z = 0;
        Instantiate(AICell, Position, Quaternion.identity);
    }
}
