using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public float SpawnSpeed;
    public string TargetTag;
    public GameObject Virus;
    private GameObject Target;

    void Start() {
        Target = null;
        InvokeRepeating("Generate", 0, SpawnSpeed);
    }

    void Generate()
    {
        if (Target == null) {
            var candidateTargets = GameObject.FindGameObjectsWithTag(TargetTag);
            if (candidateTargets.Length > 0) {
                Target = candidateTargets[0];
            }
        } else {
            int x = Random.Range(0, Camera.main.pixelWidth);
            int y = Random.Range(0, Camera.main.pixelHeight);
            Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            Position.z = 0;
            GameObject vir = Instantiate(Virus, Position, Quaternion.identity);
            Virus3DController virusController = vir.GetComponent<Virus3DController>();
            virusController.Target = Target;
        }
    }
}
