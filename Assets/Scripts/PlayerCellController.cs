using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCellController : MonoBehaviour
{
    private int proteinMoney;
    public Text deathMessage;

    private readonly float WorldSize = 100;

    void Update() {
        Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position.z = transform.position.z;
        transform.position = ClampWorld(Vector3.MoveTowards(transform.position, Position, GetComponent<PlayerCellularOrganism>().getSpeed() * Time.deltaTime));
        proteinMoney = GetComponent<EntityController>().getScore();
        if (transform.localScale.x <= 0.3 || transform.localScale.x > 25) {
            StartCoroutine(cellDeath());
        }
        if (Random.value < 0.01) {
            transform.localScale -= new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);
        }
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

    IEnumerator cellDeath()
    {
        deathMessage.text = "Game Over !\n CO Dead. Too Small or Big\n Returning to Main Screen";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
