using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnInvisible : MonoBehaviour
{
    public float damage = -1f;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "picked" && collision.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this);
    }
}