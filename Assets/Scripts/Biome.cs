using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    public GameObject Temp;
    private float damage = 0.1f;

    public float getDamage()
    {
        return damage;
    }

    public GameObject getTemp()
    {
        return Temp;
    }
}
