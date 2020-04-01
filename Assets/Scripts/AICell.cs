using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICell : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    public float Size { get; private set; }
    
    public int Points {
        get { return (int)(Size * 10); }
    }

    // Start is called before the first frame update
    void Start()
    {
        Size = Random.Range(0.5f, 3.0f);
    }
}
