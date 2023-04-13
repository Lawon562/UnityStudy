using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvartarController : MonoBehaviour
{
    public Transform stiker;
    public Transform inven;

    Vector3 stickPos;
    Vector3 invenPos;

    Rigidbody rigidbody;
    float speed = 7f;
    float rotSpeed = 120f;
    float dirV;
    float rotH;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotH = Input.GetAxis("Horizontal");
        dirV = Input.GetAxis("Vertical");

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed * dirV);
        this.transform.Translate(Vector3.up * Time.deltaTime * rotSpeed * rotH);
        characterInput();
        
    }



    private void characterInput()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //¹ß»ç
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(rig_init());
        switch (collision.gameObject.tag)
        {
            case "chark":
                //collision.gameObject.transform.position = ½ºÆ¼Ä¿ÁÂÇ¥
                collision.transform.SetParent(this.transform);
                collision.transform.GetComponent<Rigidbody>().isKinematic = true;
                stickPos = stiker.position;
                
                collision.transform.position = stickPos;
                break;
            case "carrige":
                //collision.gameObject.transform.position = ÁüÄ­ÁÂÇ¥
                collision.transform.position = invenPos;
                invenPos = new Vector3(inven.position.x, inven.position.y + 1.5f, inven.position.z);
                break;
        }
    }

    IEnumerator rig_init()
    {
        yield return new WaitForSeconds(1f);
        rigidbody.velocity = Vector3.zero;
    }
}
