using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
    // Temp, in actual will be replaced by the 'picked' object
    public int throwSpeed = 100;
    public GameObject pickedTemplate;
    GameObject throwObject = null;
    public bool isLocked;
    public bool isHit;
    public KeyCode pickKey, throwKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "picked")
        {
            // Insert code for hurt :/ :/

            Destroy(collision.gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pickable")
        {
            if (Input.GetKeyDown(pickKey))
            {
                //If object already exists, reset it and leave it in the world
                if (throwObject != null)
                {
                    throwObject.transform.parent = null;
                    throwObject.GetComponent<Collider>().enabled = true;
                    throwObject.transform.position -= new Vector3(0, 1, 0);
                    throwObject.tag = pickedTemplate.tag;
                    throwObject = null;
                }
                //TODO: Smoothen this!
                GameObject obj = other.gameObject;
                obj.transform.parent = this.gameObject.transform;
                obj.transform.position += (new Vector3(0, 1, 0)) + Quaternion.Euler(0, 90, 0) * transform.forward;
                throwObject = obj;
                throwObject.tag = pickedTemplate.tag;
                throwObject.GetComponent<Collider>().enabled = false;
            }
        }

        else if (other.gameObject.tag == "melee")
        {
            if (Input.GetKeyDown(pickKey))
            {
                if (throwObject != null)
                {
                    throwObject.transform.parent = null;
                    throwObject.GetComponent<Collider>().enabled = true;
                    throwObject.transform.position -= new Vector3(0, 1, 0);
                    throwObject.tag = pickedTemplate.tag;
                    throwObject = null;
                }

                GameObject obj = other.gameObject;
                obj.transform.parent = this.gameObject.transform;
                obj.transform.position += (new Vector3(0, 1, 0)) + Quaternion.Euler(0, 90, 0) * transform.forward;
                throwObject = obj;
                throwObject.tag = "meleepicked";
            }
        }
    }   
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && throwObject == null)
        //{
        //    throwObject = Instantiate(sphere, transform) as GameObject;
        //    throwObject.transform.position += (new Vector3(0, 1, 0)) + Quaternion.Euler(0, 90, 0) * transform.forward;
        //}
        if (Input.GetKeyDown(throwKey))
        {
            if (throwObject != null)
            {
                Rigidbody rb_obj = throwObject.GetComponent<Rigidbody>();
                throwObject.transform.parent = null;
                throwObject.GetComponent<Collider>().enabled = true;
                throwObject.GetComponent<Collider>().isTrigger = false;
                rb_obj.velocity = transform.forward * throwSpeed;
                throwObject = null;
            }
        }
    }
}
