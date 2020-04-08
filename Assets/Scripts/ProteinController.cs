using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinController : MonoBehaviour
{
    private float spawnSpeed = 1.0f;

    void Start() {
        for (int i = 0; i < 100; i++)
            Generate();
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(-100, 100);
        int y = Random.Range(-100, 100);
        Vector3 Position = new Vector3(x, y, 0);
        Instantiate(GetComponent<ProteinPointBlob>().getProtein(), Position, Quaternion.identity);
    }
}
