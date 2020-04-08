using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopMenuUI;
    public GameObject pauseMenuUI;

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        shopMenuUI.SetActive(false);

    }

    public void SpeedUp()
    {
        if (GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().getScore() >= 10)
        {
            GameObject co = GameObject.Find("PlayerCellGraphics");
            co.GetComponent<EntityController>().reduceScore(10); 
            co.GetComponent<PlayerCellularOrganism>().setSpeed(GameObject.Find("PlayerCellGraphics").GetComponent<PlayerCellularOrganism>().getSpeed() * 1.2f);
            co.GetComponent<EntityController>().UpdateSpeedText();
        }
    }

    public void ResistanceUp()
    {
        if (GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().getScore() >= 10)
        {
            GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().reduceScore(10);
        }
    }

    public void ImmunityUp()
    {
        if (GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().getScore() >= 10)
        {
            GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().reduceScore(10);
            GameObject.Find("PlayerCellGraphics").GetComponent<EntityController>().IncreaseImmunity();
        }
    }


}
