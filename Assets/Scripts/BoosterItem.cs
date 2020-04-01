using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterItem : MonoBehaviour
{
    public GameObject SpeedBooster;
    public GameObject ImmunityBooster;

    public GameObject getSpeedBooster() {
        return SpeedBooster;
    }

    public GameObject getImmunityBooster(){
        return ImmunityBooster;
    }
}
