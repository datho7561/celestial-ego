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

    // Represents if the player is currently attacking a target
    private bool Attacking;
    private float TimeAttackingOrAcquiring;

    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;       
    }

    // Update is called once per frame
    void Update()
    {
        // TODO:   
        // update the counter
        // update if attacking or acquiring target
        // if attacking, move in facing direction, regardless of the player location
        // if acquiring, rotate to face the player
    }
}
