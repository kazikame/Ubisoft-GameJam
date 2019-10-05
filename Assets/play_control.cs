using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_control : MonoBehaviour
{
    // Start called before the first frame update
    float speed = 6;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
   bool walkAnim = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per wframe
    void Update()
    {

        Vector3 temp = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
            {
                walkAnim = true;
                temp += (new Vector3(0, 0, 1)) * speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                walkAnim = true;
                temp += (new Vector3(-1, 0, 0)) * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                walkAnim = true;
                temp += (new Vector3(1, 0, 0)) * speed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                walkAnim = true;
                temp += (new Vector3(0, 0, -1)) * speed;
            }

        }
        else
        {
            walkAnim = false;
        }

        anim.SetBool("walk", walkAnim);
        moveDir = temp;
        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);
        //controller.Move(moveDir * Time.deltaTime);
    }

    void FixedUpdate()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15F);
        controller.Move(moveDir * Time.deltaTime);

    }
}
