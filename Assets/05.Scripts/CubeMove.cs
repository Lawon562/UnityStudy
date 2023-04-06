using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField]
    public static float speed = 14f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time = 0f;

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time >= 3f)
        {
            CubeMove.speed *= 1.2f;
            time = 0f;
        }
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        
    }
}
