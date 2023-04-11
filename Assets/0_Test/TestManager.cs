using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

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

    

    void Start()
    {
        if (Speed == 0f) Speed = 3f;
    }

    void Update()
    {
        obj.transform.position += (Vector3.right * Time.deltaTime * Speed * dir);
    }
}
