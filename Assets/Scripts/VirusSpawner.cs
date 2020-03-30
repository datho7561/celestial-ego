using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public float SpawnSpeed;
    public GameObject Virus;

    void Start() {
        InvokeRepeating("Generate", 0, SpawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);
        Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Position.z = 0;
        Instantiate(Virus, Position, Quaternion.identity);
    }
}
