using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5f;

    private readonly Vector3 dir = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vector3 dir = Vector3.down;
        Destroy(this.gameObject);   // 현재 객체 삭제
        // Destroy(base.gameObject);   // 현재 객체의 상위 객체를 삭제

        Destroy(collision.gameObject);
    }
}
