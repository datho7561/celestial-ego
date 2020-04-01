using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICellController : MonoBehaviour
{
    public Rigidbody rb;
    public AICell Cell;
    private float DirectionCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Quaternion.Euler(new Vector3(0, 0, Random.value * 360));
        DirectionCounter = 0;
    }

    void Update()
    {
        // I tried putting in start, but I guess Cell isn't init until after the game starts
        transform.localScale = Cell.Size * Vector3.one;
        DirectionCounter += Time.deltaTime;
        if (DirectionCounter > Cell.RotSpeed)
        {
            if (Random.value > 0.5f) {
                rb.rotation *= Quaternion.Euler(new Vector3(0, 0, Cell.RotSpeed * Time.fixedDeltaTime));
            } else {
                rb.rotation *= Quaternion.Euler(new Vector3(0, 0, -Cell.RotSpeed * Time.fixedDeltaTime));
            }
        }
    }

    // Move the cell in the direction it is facing.
    // There is a chance it changes directions.
    void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(
            Mathf.Sin(rb.rotation.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Cos(rb.rotation.eulerAngles.z * Mathf.Deg2Rad),
            0
        ).normalized;
        rb.MovePosition(rb.position + moveDir * Cell.Speed * Time.fixedDeltaTime);
    }
}
