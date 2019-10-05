using UnityEngine;

public class knight_walk : MonoBehaviour
{
	float speed = 6;


    Vector3 moveDir = Vector3.zero;
	CharacterController controller;
    int walkAnim = 0;
    int runAnim = 0;
    Animator anim;
    public KeyCode up, down, left, right, run, Study;
    public bool isBlocked = false;
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

        if (Input.GetKey(up) || Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(down))
        {
            if (Input.GetKey(up))
            {
                walkAnim = 1;
                temp += (new Vector3(0, 0, 1)) * speed;
            }

            if (Input.GetKey(left))
            {
                walkAnim = 1;
                temp += (new Vector3(-1, 0, 0)) * speed;
            }

            if (Input.GetKey(right))
            {
                walkAnim = 1;                                               
                temp += (new Vector3(1, 0, 0)) * speed;
            }

            if (Input.GetKey(down))
            {
                walkAnim = 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                temp += (new Vector3(0, 0, -1)) * speed;
            }

            if (Input.GetKey(run))
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
        if (!isBlocked && !GetComponent<Player_status>().lockControls)
        {
            anim.SetInteger("run", walkAnim & runAnim);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15F);
            controller.Move(moveDir * Time.deltaTime);
            anim.SetInteger("walk", walkAnim);
        }

    }

}
