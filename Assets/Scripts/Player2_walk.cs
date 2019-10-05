﻿using UnityEngine;

public class Player2_walk : MonoBehaviour
{
    float speed = 6;
    float rotSpeed = 160;
    float rot = 0f;
    float gravity = 8;


    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    int walkAnim = 0;
    int runAnim = 0;
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
                walkAnim = 1;
                temp += (new Vector3(0, 0, 1)) * speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                walkAnim = 1;
                temp += (new Vector3(-1, 0, 0)) * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                walkAnim = 1;
                temp += (new Vector3(1, 0, 0)) * speed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                walkAnim = 1;
                temp += (new Vector3(0, 0, -1)) * speed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                runAnim = 1;
            }
            else
            {
                runAnim = 0;
            }
        }
        else
        {
            walkAnim = 0;
        }


        temp += temp * (walkAnim & runAnim);
        moveDir = temp;


        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);
        //controller.Move(moveDir * Time.deltaTime);
    }

    void FixedUpdate()
    {
        anim.SetInteger("run", walkAnim & runAnim);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15F);
        controller.Move(moveDir * Time.deltaTime);
        anim.SetInteger("walk", walkAnim);

    }

}