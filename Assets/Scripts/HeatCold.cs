using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatCold : MonoBehaviour
{
    void Start()
    {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-50, 50);
        transform.position = new Vector3(x, y, 0);
    }
}
