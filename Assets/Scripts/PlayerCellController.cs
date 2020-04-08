using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCellController : MonoBehaviour
{
    private int proteinMoney;
    public Text deathMessage;
    public Image deathOverlay;

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
            float time = Time.deltaTime;
            transform.localScale -= new Vector3(1f * time, 1f * time, 1f * time);
            Camera.main.orthographicSize -= time;
        }
    }

    public int getMoney() {
        return proteinMoney;
    }
    
    private Vector3 ClampWorld(Vector3 original)
    {
        Vector3 copy = new Vector3(original.x, original.y, original.z);
        copy.x = copy.x < -100 ? 100 : copy.x > 100 ? -100 : copy.x;
        copy.y = copy.y < -100 ? 100 : copy.y > 100 ? -100 : copy.y;
        return copy;
        // return new Vector3(
        //     Mathf.Clamp(original.x, -WorldSize, WorldSize),
        //     Mathf.Clamp(original.y, -WorldSize, WorldSize),
        //     original.z);
    }

    IEnumerator cellDeath()
    {
        deathMessage.text = "Game Over !\n CO Dead. Too Small or Big\n Returning to Main Screen";
        deathOverlay.enabled = true;

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
