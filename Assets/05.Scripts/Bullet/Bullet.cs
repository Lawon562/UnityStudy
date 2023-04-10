using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
  
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
