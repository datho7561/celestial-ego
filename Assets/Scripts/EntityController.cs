using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityController : MonoBehaviour
{
    private string Tag = "Protein";
    private string virusTag = "Virus";
    private string otherCellTag = "OtherCell";
    private string speedTag = "SpeedBoost";
    private string immunityTag = "ImmunityBoost";
    private float Increase = 0.1f;
    private float Decrease = 0.5f;
    public Text Letters;

    private int Score = 0;

    public int getScore() {
        return Score;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tag) {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);
            Score += GetComponent<ProteinPointBlob>().getProteinValue();
            Letters.text = "Protein Currency: " + Score;
        }

        if (other.gameObject.tag == virusTag)
        {
            transform.localScale -= new Vector3(Decrease, Decrease, Decrease);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == otherCellTag)
        {
            AICell otherData = other.GetComponent<AICell>();
            if (other.transform.localScale.x > transform.localScale.x) {
                transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            } else {
                Score += otherData.Points;
                transform.localScale += new Vector3(Increase, Increase, Increase);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == speedTag)
        {
            StartCoroutine(powerUpSpeedTimer(other)); 
        }

        if (other.gameObject.tag == immunityTag)
        {
            StartCoroutine(powerUpImmunityTimer(other));
        }
    }

    IEnumerator powerUpSpeedTimer(Collider player) {
            GetComponent<PlayerCellularOrganism>().setSpeed(GetComponent<PlayerCellularOrganism>().getSpeed() * 3f);
            Destroy(player.gameObject);
            yield return new WaitForSeconds(15f);
            GetComponent<PlayerCellularOrganism>().setSpeed(GetComponent<PlayerCellularOrganism>().getSpeed() / 3f);
      
    }

    IEnumerator powerUpImmunityTimer(Collider player)
    {
        this.Decrease = 0f;
        Destroy(player.gameObject);
        yield return new WaitForSeconds(15f);
        this.Decrease = 0.5f;
    }


}
