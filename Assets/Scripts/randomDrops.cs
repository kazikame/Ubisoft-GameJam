using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class randomDrops : MonoBehaviour
{
    public GameObject obj;
    public GameObject floor;
    public GameObject table;
    private List<Vector3> positions = new List<Vector3>();
    private float timer;
    private float tabletimer;
    private float spawnperiod= 5f;
    private float spawnperiodtable = 5f;
    private int maxspawns=6;
    private void Start()
    {
        InitializePositions();
        timer = spawnperiod;
    }
    void InitializePositions()
    {
        Vector3 scale = floor.GetComponent<Collider>().bounds.size;
        Vector3 pos = floor.GetComponent<Collider>().bounds.center;
        float xrangel = pos.x - 0.5f * scale.x+0.001f * scale.x ;
        float xranger = pos.x + 0.5f * scale.x - 0.001f * scale.x;
        float zrangel = pos.z - 0.5f * scale.z + 0.001f * scale.z;
        float zranger = pos.z + 0.5f * scale.z - 0.001f * scale.z;
        for (float x = xrangel + 1; x < xranger; x++)
        {
            for (float z = zrangel + 1; z < zranger; z++)
            {
                positions.Add(new Vector3(x, pos.y+ .5f *scale.y+0.3f, z));
            }
        }
    }

    void GiveRandomPosition(GameObject gameobject)
    {
        
        Vector3 randomposition = new Vector3();
        do
        {

            int randindex = Random.Range(0, positions.Count);
            //Debug.Log(randindex.ToString());
            randomposition = positions[randindex];

        } while ((Physics.OverlapBox(randomposition, gameobject.GetComponent<Collider>().bounds.size / 2)).Length > 0);
        Instantiate(gameobject, randomposition, Quaternion.identity,transform);
    }
    // Start is called before the first frame update
    void SpawnTable(GameObject gameobject)
    {
        Vector3 randomposition = new Vector3();
        do
        {

            int randindex = Random.Range(0, positions.Count);
            //Debug.Log(randindex.ToString());
            randomposition = positions[randindex] + new Vector3(0f, gameobject.GetComponent<Collider>().bounds.size.y / 2 + 0.5f, 0f);

        } while ((Physics.OverlapBox(randomposition, gameobject.GetComponent<Collider>().bounds.size / 2)).Length > 0);
        //Instantiate(gameobject, randomposition, Quaternion.identity);
        gameobject.transform.position = randomposition;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < 0 && transform.childCount<maxspawns)
        {
            GiveRandomPosition(obj);
        
            timer = spawnperiod;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (tabletimer < 0 && !table.GetComponent<Table>().studying)
        {
            SpawnTable(table);
            tabletimer = spawnperiodtable;
        }
        else
        {
            tabletimer -= Time.deltaTime;
        }
    }
}