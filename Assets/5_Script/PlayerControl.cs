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
        // �̵� �� ��ǥ��� ��� �������� �� ���ΰ�?(�� ��ü ���� xyz)
        // Space.Self ; ����
        // Space.World; ���� ��ǥ ����
        // ��ǥ ü�踦 ���þ��� ���� -> �⺻������ local(self)������ ��ǥ��� �̵��Ѵ�.
        this.transform.Rotate(Vector3.up * Time.deltaTime * rot * 120f);
        
    }

}
