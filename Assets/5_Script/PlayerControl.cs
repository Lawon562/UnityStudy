using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * 2f);
    }
}
