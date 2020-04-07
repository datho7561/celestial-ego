using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellularOrganism : MonoBehaviour
{
    private float Speed = 7.0f;
    private int proteinCurrency;
    public float size;

    void Update() { 
        proteinCurrency = GetComponent<PlayerCellController>().getMoney();
    }

    public float getSpeed() {
        return Speed;
    }

    
    public int getProteinCurrency() {
        return proteinCurrency;
    }

    public void setSpeed(float speed) {
        this.Speed = speed;
    }

}
