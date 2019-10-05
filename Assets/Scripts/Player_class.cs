using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_class : MonoBehaviour
{
    // Start is called before the first frame update

    public const int StunDuration = 4;
    private float cpi;
    public float diskDamage = 1f;
    public float magDamage = 0.5f;
    public float melDamage = 0.2f;



    public float CPI
    {
        get
        {
            return cpi;
        }
        set
        {
            cpi = value;
        }

    }

    private int state; // 0 - free movement, 1 - stunned, 2 - studying

    public int State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
            
    }
    
}
