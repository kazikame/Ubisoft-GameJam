using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
    // Temp, in actual will be replaced by the 'picked' object
    public GameObject sphere;
    public int throwSpeed = 100;
    GameObject throwObject = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && throwObject == null)
        {
            throwObject = Instantiate(sphere, transform) as GameObject;
            throwObject.transform.position += (new Vector3(0, 1, 0)) + Quaternion.Euler(0, 90, 0) * transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (throwObject != null)
            {
                Rigidbody rb_obj = throwObject.GetComponent<Rigidbody>();
                throwObject.transform.parent = null;
                rb_obj.velocity = transform.forward * throwSpeed;
                throwObject = null;
            }
        }
    }
}
