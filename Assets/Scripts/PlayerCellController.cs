using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellController : MonoBehaviour
{
    private int proteinMoney;

    private readonly float WorldSize = 100;

    void Update() {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position.z = transform.position.z;
        transform.position = ClampWorld(Vector3.MoveTowards(transform.position, Position, GetComponent<PlayerCellularOrganism>().getSpeed() * Time.deltaTime / transform.localScale.x));
        proteinMoney = GetComponent<EntityController>().getScore();
    }

    public int getMoney() {
        return proteinMoney;
    }
    
    private Vector3 ClampWorld(Vector3 original)
    {
        return new Vector3(
            Mathf.Clamp(original.x, -WorldSize, WorldSize),
            Mathf.Clamp(original.y, -WorldSize, WorldSize),
            original.z);
    }
}
