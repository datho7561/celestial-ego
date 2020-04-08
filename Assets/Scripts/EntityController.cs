using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityController : MonoBehaviour
{
    private string proteinTag = "Protein";
    private string virusTag = "Virus";
    private string otherCellTag = "OtherCell";
    private string extTag = "ExtremeTemp";
    private string speedTag = "SpeedBoost";
    private string immunityTag = "ImmunityBoost";
    private float Increase = 0.1f;
    private float Decrease = 0.5f;
    private float CameraScale = 1f;
    public Text Letters;
    public Text ImmunityNumber;
    public Text SizeText;
    public Text SpeedText;

    private int Score = 0;
    private int ImmunityNum = 0;

    public int getScore() {
        return Score;
    }

    public int getImmunity()
    {
        return ImmunityNum;
    }

    public void reduceScore(int point)
    {
        Score -= point;
        Letters.text = "Protein Currency: " + Score;
    }

    public void IncreaseImmunity()
    {
        ImmunityNum += 1;
        ImmunityNumber.text = "Immunity: " + ImmunityNum;
    }

    public void UpdateSpeedText()
    {
        SpeedText.text = "Speed: " + GetComponent<PlayerCellularOrganism>().getSpeed();
    }

    public void UpdateSizeText()
    {
        SizeText.text = "Size: " + transform.localScale.x;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == proteinTag) {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            Destroy(other.gameObject);
            Score += GetComponent<ProteinPointBlob>().getProteinValue();
            Camera.main.orthographicSize += CameraScale*Increase;
        }

        if (other.gameObject.tag == virusTag)
        {
            if (ImmunityNum == 0)
            {
                transform.localScale -= new Vector3(Decrease, Decrease, Decrease);
                Camera.main.orthographicSize -= CameraScale*Decrease;
            }
            else
            {
                ImmunityNum -= 1;
                ImmunityNumber.text = "Immunity: " + ImmunityNum;
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == otherCellTag)
        {
            AICell otherData = other.GetComponent<AICell>();
            if (other.transform.localScale.x > transform.localScale.x) {
                transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            } else {
                Score += otherData.Points;
                //transform.localScale += new Vector3(Increase, Increase, Increase);
                float newSize = Mathf.Pow(Mathf.Pow(transform.localScale.x, 3f) + Mathf.Pow(other.transform.localScale.x, 3f), 1 / 3f);
                transform.localScale = new Vector3(newSize, newSize, newSize);
                Camera.main.orthographicSize += CameraScale*Mathf.Pow(other.transform.localScale.x, 1 / 3f);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == extTag)
        {
            if (Random.Range(0,10)<1)
            {
                transform.localScale -= new Vector3(Decrease, Decrease, Decrease);
                Camera.main.orthographicSize -= CameraScale * Decrease;
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

        // Update the UI accordingly
        Letters.text = "Protein Currency: " + Score;
        UpdateSizeText();
        UpdateSpeedText();
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
