using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus3DController : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    public float Size;
    public float Damage;
    public float TargettingTime;
    public float AttackingTime;
    public GameObject Target;
    public Rigidbody rb;

    private float TimeElapsed;
    private bool attacking;

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
            Vector3 lookPosition = (Target.transform.position - rb.position).normalized;
            lookPosition.z = 0.0f;
            // Get the current z rotation from the rotation quaternion
            float currentAngle = rb.rotation.eulerAngles.z;
            if (attacking) {
                Vector3 moveDir = new Vector3(
                    Mathf.Cos((currentAngle + 90.0f) * Mathf.Deg2Rad),
                    Mathf.Sin((currentAngle + 90.0f) * Mathf.Deg2Rad),
                    0
                ).normalized;
                rb.MovePosition(rb.position + moveDir * Speed * Time.fixedDeltaTime);
            } else {
                float targetAngle = Mathf.Atan2(lookPosition.y, lookPosition.x) * Mathf.Rad2Deg - 90.0f;
                float deltaAngle;
                if (currentAngle > targetAngle) {
                    deltaAngle = -(currentAngle - targetAngle);
                    if (deltaAngle < -180) {
                        deltaAngle = 360 + deltaAngle;
                    }
                } else {
                    deltaAngle = targetAngle - currentAngle;
                    if (deltaAngle > 180) {
                        deltaAngle = 360 - deltaAngle;
                    }
                }
                deltaAngle = Mathf.Clamp(deltaAngle, - RotSpeed * Time.fixedDeltaTime, RotSpeed * Time.fixedDeltaTime);
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, deltaAngle));
                rb.rotation = rb.rotation * deltaRotation;
            }
        }
    }
}
