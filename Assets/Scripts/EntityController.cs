using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private string Tag = "Protein";
    private float Increase = 0.1f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tag) {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);
        }
    }
}
