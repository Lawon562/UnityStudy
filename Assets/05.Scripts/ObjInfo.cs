using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"나 클라우드 : 강체 {collision.collider.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"나 클라우드 : 기체 {other.name}");
        if (other.name == "water")
        {
            other.gameObject.SetActive(false);
        }
    }
}
