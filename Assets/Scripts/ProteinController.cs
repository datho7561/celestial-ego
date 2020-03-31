using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinController : MonoBehaviour
{
    private float spawnSpeed = 0.3f;

    void Start() {
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        Vector3 Position = new Vector3(x, y, 0);
        Instantiate(GetComponent<ProteinPointBlob>().getProtein(), Position, Quaternion.identity);
    }
}
