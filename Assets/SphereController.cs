using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

    void Start()
    {
        //Invoke("independ", 10f);
    }

    void independ()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Captured()
    {
        Invoke("independ", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
