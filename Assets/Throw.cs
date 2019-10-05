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
    public KeyCode attackKey;
    public GameObject nahiPadha;
    GameObject textbox = null;
    float text_gen_time;
    public float textEps = 1f;
    public float eps_angle = 50f;

    public float hitEps = 3f;
    public int hitCount = 3;
    public int hits_taken = 0;
    float last_hit_time;
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
            Debug.Log("Inside pickable");
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
        if (other.gameObject.tag == "player")
        {
            //if (Input.GetKeyDown(other.gameObject.GetComponent<Throw>().attackKey))
            //{
            //    // Insert code for hurt :/ :/
            //    Debug.Log("Hurt :/ :/");
            //}

            if (Input.GetKeyDown(attackKey) && Vector3.Angle(other.transform.position - transform.position, GetComponent<Collider>().transform.forward) < eps_angle)
            {
                if (textbox != null)
                    Destroy(textbox);
                textbox = Instantiate(nahiPadha, transform, false);
                textbox.transform.position += new Vector3(0, 4, 0);
                text_gen_time = Time.time;
                other.gameObject.GetComponent<Throw>().hits_taken++;
            }
        }
        //else if (other.gameObject.tag == "melee")
        //{
        //    if (Input.GetKeyDown(pickKey))
        //    {
        //        if (throwObject != null)
        //        {
        //            throwObject.transform.parent = null;
        //            throwObject.GetComponent<Collider>().enabled = true;
        //            throwObject.transform.position -= new Vector3(0, 1, 0);
        //            throwObject.tag = pickedTemplate.tag;
        //            throwObject = null;
        //        }

        //        GameObject obj = other.gameObject;
        //        obj.transform.parent = this.gameObject.transform;
        //        obj.transform.position += (new Vector3(0, 1, 0)) + Quaternion.Euler(0, 90, 0) * transform.forward;
        //        throwObject = obj;
        //        throwObject.tag = "meleepicked";
        //    }
        //}
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
        Debug.Log(transform.forward);
        if (textbox != null)
        {
            if (Time.time - text_gen_time > textEps)
            {
                Destroy(textbox);
                textbox = null;
            }
        }

        if (hits_taken > 0)
        {
            if (Time.time - last_hit_time > hitEps)
            {
                hits_taken = 0;
            }
            else if (hits_taken >= 3)
            {
                // STUNNNNNN!
                hits_taken = 0;
            }
        }
    }
}