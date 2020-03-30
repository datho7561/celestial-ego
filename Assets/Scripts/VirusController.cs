using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{

    // This is the GameObject that the Virus will attack
    public GameObject TargetCellularOrganism;
    // This is how long the Virus will take to find its target
    public float TimeToFindTarget;
    // This is how long the virus will move towards the player for when attacking
    public float TimeToAttackTarget;
    // Instance of Virus that this is controlling
    public Virus ControlledVirus;

    // Represents if the player is currently attacking a target
    private bool Attacking;
    private float TimeAttackingOrAcquiring;

    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;       
        TimeAttackingOrAcquiring = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // update the counter
        TimeAttackingOrAcquiring += Time.deltaTime;
        if (Attacking) {
            if (TimeAttackingOrAcquiring > TimeToAttackTarget) {
                TimeAttackingOrAcquiring = 0;
                Attacking = false;
            }
            // When attacking, move in the direction the virus is facing
            // https://stackoverflow.com/questions/39809617/move-an-object-in-the-direction-it-is-facing-c-sharp#39809858
            transform.position += transform.forward * Time.deltaTime * ControlledVirus.Speed;
        } else {
            if (TimeAttackingOrAcquiring > TimeToAttackTarget) {
                TimeAttackingOrAcquiring = 0;
                Attacking = false;
            }
            // If acquiring target, rotate to face the player
            transform.forward = new Vector3(
                transform.position.x - TargetCellularOrganism.transform.position.x,
                transform.position.y - TargetCellularOrganism.transform.position.y, 0).normalized;
        }
    }
}
