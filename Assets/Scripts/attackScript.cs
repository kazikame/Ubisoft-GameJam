using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("attackNow"))
        {
            anim.SetBool("attackNow", false);
        }

        else
        {
            if (Input.GetKeyDown(GetComponent<Throw>().attackKey))
            {
                anim.SetBool("attackNow", true);
            }
        }
    }
}
