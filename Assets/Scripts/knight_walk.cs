using UnityEngine;

public class knight_walk : MonoBehaviour
{
	float speed = 6;
	float rotSpeed = 160;
    float rot = 0f;
	float gravity = 8;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;

    public KeyCode Study = KeyCode.E;
    public bool iamstudying;
    public int playerID = 1;
    public int CPI = 6;
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
        if (!this.GetComponent<Player_status>().lockControls)
        {
            Vector3 temp = Vector3.zero;



            if (Input.GetKey(Up) || Input.GetKey(Left) || Input.GetKey(Right) || Input.GetKey(Down))
            {
                if (Input.GetKey(Up))
                {
                    walkAnim = 1;
                    temp += (new Vector3(0, 0, 1)) * speed;
                }

                if (Input.GetKey(Left))
                {
                    walkAnim = 1;
                    temp += (new Vector3(-1, 0, 0)) * speed;
                }

                if (Input.GetKey(Right))
                {
                    walkAnim = 1;
                    temp += (new Vector3(1, 0, 0)) * speed;
                }

                if (Input.GetKey(Down))
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
    }

    void FixedUpdate()
    {
        anim.SetInteger("run", walkAnim & runAnim);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.15F);
        controller.Move(moveDir * Time.deltaTime);
        anim.SetInteger("walk", walkAnim);

    }

}
