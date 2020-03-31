using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    public float Size;
    public float Damage;
    public float TargettingTime;
    public float AttackingTime;
    public GameObject Target;
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
        if (Target)
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
        if (Target != null) {
            Vector2 targetLoc = new Vector2(Target.transform.position.x, Target.transform.position.y);
            Vector2 lookPosition = (targetLoc - rb.position).normalized;
            if (attacking) {
                Vector2 moveDir = new Vector2(Mathf.Cos((rb.rotation + 90.0f) * Mathf.Deg2Rad), Mathf.Sin((rb.rotation + 90.0f) * Mathf.Deg2Rad)).normalized;
                rb.MovePosition(rb.position + moveDir * Speed * Time.fixedDeltaTime);
            } else {
                float targetAngle = Mathf.Atan2(lookPosition.y, lookPosition.x) * Mathf.Rad2Deg - 90.0f;
                float deltaAngle = System.Math.Sign(targetAngle - rb.rotation) * System.Math.Min(System.Math.Abs(targetAngle - rb.rotation), System.Math.Abs(RotSpeed * Time.fixedDeltaTime));
                rb.rotation += deltaAngle;
            }
        }
    }
}
