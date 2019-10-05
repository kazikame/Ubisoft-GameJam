using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode attackKey2;
    private bool lol = true;
    Animator anim;
    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey2))
        {
            Debug.Log("Inside Update!");
            anim.SetBool("canAttack", lol);
            Debug.Log(anim.GetBool("canAttack"));
            lol = !lol;
        }
    }
}
