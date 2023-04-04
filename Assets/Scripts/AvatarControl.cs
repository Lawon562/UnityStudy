using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControl : MonoBehaviour
{
    float Speed = 20f;

    void Start()
    {
        //  transform.position = Vector3.zero;
    }

    void Update()
    {
        //float x = Input.GetAxisRaw("Horizontal") * -1;
        float x = Input.GetAxisRaw("Horizontal");
        //float z = Input.GetAxisRaw("Vertical") * -1;
        float z = Input.GetAxisRaw("Vertical");
        Debug.Log($"{"A"}");

        if (x != 0f || z != 0f)
        {
            Vector3 dir = new Vector3(x, 0, z);
            //transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * z * Time.deltaTime * Speed);
            transform.Rotate(Vector3.up * x * Time.deltaTime * Speed * Speed);
        }
    }
}
