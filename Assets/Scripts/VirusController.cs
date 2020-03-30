using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float Speed;
    public float Size;
    public float Damage;
    public GameObject Target;
    public float TargettingTime;
    public float AttackingTime;
    public Rigidbody2D rb;

    private float TimeElapsed;
    private bool attacking;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        TimeElapsed = 0.0f;
    }

    // Called every frame to handle the "AI"
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        if (attacking) {
            if (TimeElapsed > AttackingTime) {
                TimeElapsed = 0;
                attacking = false;
            }
        } else {
            if (TimeElapsed > TargettingTime) {
                TimeElapsed = 0;
                attacking = true;
            }
        }
    }

    // For applying movement to the rigidbody
    void FixedUpdate() {
        Vector2 targetLoc = new Vector2(Target.transform.position.x, Target.transform.position.y);
        Debug.Log(targetLoc);
        rb.MovePosition(rb.position + targetLoc * Speed * Time.fixedDeltaTime);
        // if (attacking) {
        //     rb.MovePosition(rb.position + targetLoc * Speed * Time.fixedDeltaTime);
        // } else {
        //     Vector2 lookPosition = targetLoc - rb.position;
        //     float angle = Mathf.Atan2(lookPosition.y, lookPosition.x) * Mathf.Rad2Deg - 90.0f;
        //     rb.rotation = angle;
        // }
    }
}
