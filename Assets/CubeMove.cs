using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ���� ����
        print("���� ���� 1" + Vector3.forward);

        //���� ���� - ���带 �������� ���� ����(this)�� ���⺤��
        print("���� ���� 2" + this.transform.forward);
        
    }
    public bool checkbox = false;
    // Update is called once per frame
    void Update()
    {
        // ������ǥ�� �̵�
        //this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
        // ������ǥ�� �̵�
        //this.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        // ���带 ��������
        // ���忡�� �ٶ� �� ��ü�� �� �������� �̵�.
        //if(checkbox) this.transform.Translate(this.transform.forward * Time.deltaTime, Space.World);
        //else this.transform.Translate(this.transform.forward * Time.deltaTime, Space.Self);

        //this.transform.position += Vector3.forward * Time.deltaTime;
        this.transform.position += this.transform.forward * Time.deltaTime;
    }
}
