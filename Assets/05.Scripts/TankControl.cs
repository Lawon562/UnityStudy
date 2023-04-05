using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    float speed = 5f;
    float rotSpeed = 120f;
    float dirFoward;
    float rotLR;
    // Start is called before the first frame update
    void Start()
    {
        dirFoward = 0;
        rotLR = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dirFoward = Input.GetAxis("Vertical");
        rotLR = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed * dirFoward);
        this.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * rotLR);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("강체 충돌 발생");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("기체 충돌 발생");
        if (other.name == "water")
        {
            other.gameObject.SetActive(false);
        }
    }
}
