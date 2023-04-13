using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        RotateCamera(mouseX, mouseY);
        ZoomCamera(mouseWheel);
    }

    void RotateCamera(float mouseX, float mouseY)
    {
        // ȸ�� �ӵ� ���� ����
        float rotationSpeed = 2.0f;

        // X�� ���� ȸ�� ó�� (���� ȸ��)
        transform.Rotate(Vector3.left, mouseY * rotationSpeed, Space.Self);

        // Y�� ���� ȸ�� ó�� (�¿� ȸ��)
        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
    }

    void ZoomCamera(float mouseWheel)
    {
        // ī�޶��� ���� Z�� �������� �� ��/�ƿ�
        Vector3 zoom = new Vector3(1, 1, transform.localScale.z - (mouseWheel));
        zoom.z = Mathf.Clamp(zoom.z, 0.3f, 1.3f);
        transform.localScale = zoom;
    }
}
