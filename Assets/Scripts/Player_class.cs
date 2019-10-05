using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_class : MonoBehaviour
{
    // Start is called before the first frame update

    public const int StunDuration = 4;
    public float CPI;
    public float StunTimer;
    public int state; // 0 - free movement, 1 - stunned, 2 - studying


    void Start()
    {
        CPI = 8.0f;
        StunTimer = 0;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
