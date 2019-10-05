using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject outerwall;
    public GameObject magazine;
    public GameObject disk;
    public GameObject table;
    public GameObject player;
    private List<Vector3> positions = new List<Vector3>();

    void InitializePositions()
    {
        Vector3 scale = floor.transform.localScale;
        Vector3 pos = floor.transform.position;
        float xrangel = pos.x - 0.5f * scale.x + 0.5f;
        float xranger = pos.x + 0.5f * scale.x - 0.5f;
        float zrangel = pos.z - 0.5f * scale.z + 0.5f;
        float zranger = pos.z + 0.5f * scale.z - 0.5f;
        for (float x = xrangel+1;x < xranger; x++)
        {
            for(float z = zrangel+1;z < zranger; z++)
            {
                positions.Add(new Vector3(x, 0f, z));
            }
        }
    }

    public void PlaceWalls()
    {
        Vector3 scale = floor.transform.localScale;
        Vector3 pos = floor.transform.position;
        float xrangel = pos.x - 0.5f*scale.x - 0.5f;
        float xranger = pos.x + 0.5f*scale.x + 0.5f;
        float zrangel = pos.z - 0.5f*scale.z - 0.5f;
        float zranger = pos.z + 0.5f*scale.z + 0.5f;
        for (float x = xrangel; x < xranger; x++)
        {
       
            Instantiate(outerwall, new Vector3(x, 0.5f*(-scale.y+outerwall.transform.localScale.y), zrangel), Quaternion.identity);

        }
        for(float z = zrangel; z < zranger; z++)
        {
            Instantiate(outerwall, new Vector3(xranger, 0.5f * (-scale.y + outerwall.transform.localScale.y), z), Quaternion.identity);
        }
        for(float x = xranger; x > xrangel; x--)
        {
            Instantiate(outerwall, new Vector3(x, 0.5f * (-scale.y + outerwall.transform.localScale.y), zranger), Quaternion.identity);
        }
        for(float z = zranger; z > zrangel; z--)
        {
            Instantiate(outerwall, new Vector3(xrangel, 0.5f * (-scale.y + outerwall.transform.localScale.y), z), Quaternion.identity);
        }

        
       

    }
    
    void GiveRandomPosition(GameObject gameobject)
    {
        Vector3 randomposition = new Vector3();
        do
        {
           
            int randindex = Random.Range(0, positions.Count);
            randomposition = positions[randindex];
            
        } while ((Physics.OverlapBox(randomposition, gameobject.transform.localScale / 2)).Length != 0);
        Instantiate(gameobject, randomposition, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Awake()
    {
        InitializePositions();
        GiveRandomPosition(disk);
        GiveRandomPosition(magazine);
        Instantiate(floor, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(table, new Vector3(0f, 1f, 0f), Quaternion.identity);
        Instantiate(player, new Vector3(0f, 0.5f, floor.transform.position.z + 0.4f * floor.transform.localScale.z), Quaternion.Euler(new Vector3(0,180,0)));
        PlaceWalls();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
