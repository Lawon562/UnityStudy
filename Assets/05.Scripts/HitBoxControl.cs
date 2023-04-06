using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        // To-do Something
    }

    private void OnTriggerExit(Collider other)
    {
        
        GameManager.pool.RemoveAt(0);
        
        Destroy(other.gameObject);
    }

}
