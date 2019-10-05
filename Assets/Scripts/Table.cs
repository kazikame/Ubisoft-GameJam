using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public bool studying;
    public GameObject[] Players;
    private float updatePositionTime = 5f;
    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        studying = false;
    }

    //bool isNearKeyPress(GameObject player)
    //{
    //    if (Vector3.Distance(player.transform.position, )
    //    if(Input.GetKey(player.GetComponent<knight_walk>.Study))
    //}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Something near");
        if (other.gameObject.tag == "Player")
        {
            GameObject nearPlayer = other.gameObject;
            if (Input.GetKey(nearPlayer.GetComponent<knight_walk>().Study))
            {
                studying = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < Players.Length; i++)
        //{
        //    if (isNearAndKeyPress(Players[i]))
        //    {
        //        studying = true;

        //    }
        //}
        if (studying)
        {

        }
    }
}
