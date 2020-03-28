using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellController : MonoBehaviour
{

    void Update() {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, Position, GetComponent<PlayerCellularOrganism>().getSpeed() * Time.deltaTime / transform.localScale.x);
    }
}
