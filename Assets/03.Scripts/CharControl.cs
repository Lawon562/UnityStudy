using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
 * 1.특정 물체는 사라집니다
 * 2.
 * 3.
 */



public class CharControl : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rotationSpeed = 120f;
    private Rigidbody rb;
    private float x, z;
    private int jumpCount = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        z = 0;
        moveSpeed = 5f;
        rotationSpeed = 120f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CharMove();
        CharJump();
    }

    private void CharMove()
    {
        
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        float moveRate = Time.deltaTime * moveSpeed * z;
        float rotationRate = Time.deltaTime * rotationSpeed * x;

        this.transform.Translate(Vector3.forward * moveRate, Space.Self);
        this.transform.Rotate(Vector3.up * rotationRate, Space.Self);
    }

    private void CharJump()
    {
        if (jumpCount < 2 && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 300f, ForceMode.Impulse);
            jumpCount++;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Land") jumpCount = 0;
        print(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Destroyable")
        {
            Destroy(other.gameObject);
        }
        
    }
}
