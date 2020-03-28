using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinController : MonoBehaviour
{
    private float spawnSpeed = 0.5f;

    void Start() {
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);
        Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Position.z = 0;
        Instantiate(GetComponent<ProteinPointBlob>().getProtein(), Position, Quaternion.identity);
    }
}
