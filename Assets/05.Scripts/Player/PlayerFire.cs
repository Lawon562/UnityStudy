using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] 
    private GameObject bulletFactory;

    [SerializeField] 
    private Transform firePosition;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform bulletPos = Instantiate(this.bulletFactory).transform;
            bulletPos.position = firePosition.transform.position + new Vector3(0, 1, 0);
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
        }
    }

    [SerializeField]
    private GameObject particle;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = Instantiate(this.particle);
        obj.transform.position = this.transform.position;
        Destroy(obj, 1f);
    }
}
