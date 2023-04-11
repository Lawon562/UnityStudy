using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamScroll : MonoBehaviour
{
    //[SerializeField]
    //private GameObject obj;

    private Camera camera;

    [SerializeField]
    private float Speed;
    float dir = 0f;

    public void OnPointDownMoveLeft()
    {
        dir = -1f;
    }

    public void OnPointDownMoveRight()
    {
        dir = 1f;
    }

    public void OnClickUp()
    {
        dir = 0f;
    }

    public void CamScrolling()
    {
        camera.transform.position += (Vector3.right * Time.deltaTime * Speed * dir);
        Vector3 tempPos = camera.transform.position;
        tempPos.x = Mathf.Clamp(tempPos.x, -30, 38);
        camera.transform.position = tempPos;
    }


    void Start()
    {
        if (Speed == 0f) Speed = 3f;
        camera = Camera.main;
    }

    void Update()
    {
        CamScrolling();
    }
}