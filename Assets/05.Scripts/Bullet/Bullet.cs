using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private float speed;
=======
    private float speed = 30f;
>>>>>>> c4571b26e3a232e7d76c93c8f6c902e348e6aeb9
  
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
