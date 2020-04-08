using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatCold : MonoBehaviour
{
    void Start()
    {
        int x_size = Random.Range(2, 10);
        int y_size = Random.Range(x_size/2, 2*x_size);
        int x = Random.Range(-50, 50 - x_size);
        int y = Random.Range(-50, 50 - y_size);
        Vector3 Position = new Vector3(x, y, 0);
        Instantiate(GetComponent<Biome>().getTemp(), Position, Quaternion.identity);
    }
}
