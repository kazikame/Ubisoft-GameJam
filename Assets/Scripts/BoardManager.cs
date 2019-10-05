using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject wall;
    public GameObject magazine;
    public GameObject disk;
    public GameObject table;
    public GameObject cube;
    private List<Vector3> positions = new List<Vector3>();

    public void PlaceWalls()
    {
        Vector3 scale = floor.transform.localScale;
        Vector3 pos = floor.transform.position;
        float xrangel = pos.x - scale.x + 0.5f;
        float xranger = pos.x + scale.x - 0.5f;
        float zrangel = pos.z - scale.z + 0.5f;
        float zranger = pos.z + scale.z - 0.5f;
        for (float x = xrangel; x < xranger; x++)
        {
       
            Instantiate(wall, new Vector3(x, 0f, zrangel), Quaternion.identity);

        }
        for(float z = zrangel; z < zranger; z++)
        {
            Instantiate(wall, new Vector3(xranger, 0f, z), Quaternion.identity);
        }
        for(float x = xranger; x > xrangel; x--)
        {
            Instantiate(wall, new Vector3(x, 0f, zranger), Quaternion.identity);
        }
        for(float z = zranger; z > zrangel; z--)
        {
            Instantiate(wall, new Vector3(xrangel, 0f, z), Quaternion.identity);
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        PlaceWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
