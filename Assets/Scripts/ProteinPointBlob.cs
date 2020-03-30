using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinPointBlob : MonoBehaviour
{
    public GameObject Protein;
    private int proteinValue = 1;

    public int getProteinValue() {
        return proteinValue;
    }

    public GameObject getProtein() {
        return Protein;
    }
}
