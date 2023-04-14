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
        float mouseX = Input.GetAxis("Mouse X");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float rotationSpeed = 2.0f;
        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);

        if (v != 0f || h!=0f)
        {

            Vector3 dir = (Vector3.right * h).normalized;
            //this.transform.rotation = Quaternion.LookRotation(dir);
            //this.transform.Translate(dir * Time.deltaTime * 10f, Space.Self);
            this.transform.Translate(Vector3.forward * Time.deltaTime * 10f, Space.Self);

                
            //this.transform.Translate(Vector3.right * Time.deltaTime * h * 10f, Space.Self);
        }

    }
}
