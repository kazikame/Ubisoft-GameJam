using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject healthbar1;
    public GameObject healthbar2;

    void Start()
    {
        Instantiate(healthbar1, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(healthbar2, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
