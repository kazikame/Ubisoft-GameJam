using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_status : MonoBehaviour
{
    // Start is called before the first frame update
    public float CPI;
    public bool isHit;
    public bool lockControls;
    public bool stunLock;
    public int stunTimer = 4;
    public int playerID;

    void Start()
    {
        CPI = 6.0f;
        isHit = false;
        lockControls = false;
        stunLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
