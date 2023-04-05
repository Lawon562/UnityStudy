using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float Speed = 3f;

    [SerializeField]
    private float rot;

    private void Start()
    {
        
    }
    

    private void Update()
    {
        float x = Input.GetAxis("SideStep");
        float z = Input.GetAxis("Vertical");
        rot = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right * Time.deltaTime * x * Speed,Space.Self);
        this.transform.Translate(Vector3.forward * Time.deltaTime * z * Speed,Space.Self);
        // 이동 시 좌표계는 어디를 기준으로 할 것인가?(내 객체 기준 xyz)
        // Space.Self ; 로컬
        // Space.World; 월드 좌표 기준
        // 좌표 체계를 세팅안한 상태 -> 기본적으로 local(self)기준의 좌표계로 이동한다.
        this.transform.Rotate(Vector3.up * Time.deltaTime * rot * 120f);
        
    }

}
