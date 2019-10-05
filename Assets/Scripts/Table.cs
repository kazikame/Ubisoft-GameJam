using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public bool studying;
    public GameObject[] Players;
    private float studyTime = 5f;
    private float elapsed = 0;
    private GameObject current_player;
    private List<Vector3> positions = new List<Vector3>();

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

        if (!studying && other.gameObject.tag == "Player")
        {
            GameObject nearPlayer = other.gameObject;
            //Debug.Log("Player Near");
            if (Input.GetKeyDown(nearPlayer.GetComponent<knight_walk>().Study))
            {
                studying = true;
                elapsed = 0;
                current_player = nearPlayer;
                nearPlayer.GetComponent<Player_status>().lockControls = true;
                Debug.Log("New player studying");
            }
        }
    }

    void Update()
    {
        if (studying)
        {
            if (Input.GetKeyUp(current_player.GetComponent<knight_walk>().Study)|| current_player.GetComponent<Player_status>().isHit == true)
            {
                studying = false;
                current_player.GetComponent<Player_status>().lockControls = false;
                current_player.GetComponent<Player_status>().isHit = false;
                elapsed = 0;
            }
            else
            {
                elapsed += Time.deltaTime;
                Debug.Log("Studying :D");
                if (elapsed > studyTime)
                {
                    elapsed = 0;
                    studying = false;
                    //
                    current_player.GetComponent<Player_status>().CPI += 4;
                    current_player.GetComponent<Player_status>().lockControls = false;
                    current_player.GetComponent<Player_status>().isHit = false;
                }
            }
        }
        //for (int i = 0; i < Players.Length; i++)
        //{
        //    if (isNearAndKeyPress(Players[i]))
        //    {
        //        studying = true;

        //    }
        //}
        //elapsed += Time.deltaTime;
        //if (elapsed > updatePositionTime)
        //{
        //    if (! studying)
        //    {
        //        Vector3 randomposition;
        //        do
        //        {
        //            int randindex = Random.Range(0, positions.Count);
        //            randomposition = positions[randindex];
        //        } while ((Physics.OverlapBox(randomposition, gameobject.transform.localScale / 2)).Length != 0);
        //        Instantiate(gameobject, randomposition, Quaternion.identity);
        //    }
        //}



    }

    //    else if (Input.GetKey(nearPlayer.GetComponent<knight_walk>().Study) && studying && (elapsed < studyTime) && (nearPlayer.GetComponent<knight_walk>().playerID == current_player))
    //    {
    //        studying = true;
    //        elapsed = elapsed + Time.deltaTime;
    //        Debug.Log("Player " + current_player.ToString() + " studying: " + elapsed.ToString());
    //    }
    //    else if (Input.GetKey(nearPlayer.GetComponent<knight_walk>().Study) && studying && (elapsed > studyTime) && (nearPlayer.GetComponent<knight_walk>().playerID == current_player))
    //    {
    //        Debug.Log("CPI Awarded :D");
    //        studying = false;
    //        elapsed = 0;
    //        current_player = -1;
    //        nearPlayer.GetComponent<knight_walk>().CPI += 10;
    //        // Award points nearPlayer.GetComponent<player_health>  changeCPI(0.5);
    //    }
    //    else
    //    {
    //        elapsed += Time.deltaTime;
    //    }
    //        //    studying = false;
    //        //    elapsed = 0;
    //        //    current_player = -1;

    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    studying = false;
    //    elapsed = 0;
        
    //    Debug.Log("No one studying");
    //}
    // Update is called once per frame
    
}
