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
        }
    }
}
