using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnInvisible : MonoBehaviour
{
    public float damage = -1f;
    // Start is called before the first frame update
    void OnBecameInvisible()
    {
        Destroy(this);
    }
}