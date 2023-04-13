using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    void Start()
    {
        
    }

    public static Vector3 dirY = new Vector3();

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        

        if (v != 0f || h!=0f)
        {
            
            this.transform.Translate(Vector3.forward * Time.deltaTime * v * 10f, Space.World);
            this.transform.Translate(Vector3.right * Time.deltaTime * h * 10f, Space.World);
        }

    }
}
