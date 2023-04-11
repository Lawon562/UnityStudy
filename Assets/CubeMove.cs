using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 방향 벡터
        print("벡터 방향 1" + Vector3.forward);

        //방향 벡터 - 월드를 기준으로 잡은 로컬(this)의 방향벡터
        print("방향 벡터 2" + this.transform.forward);
        
    }
    public bool checkbox = false;
    // Update is called once per frame
    void Update()
    {
        // 로컬좌표로 이동
        //this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
        // 월드좌표로 이동
        //this.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        // 월드를 기준으로
        // 월드에서 바라본 내 객체의 앞 방향으로 이동.
        //if(checkbox) this.transform.Translate(this.transform.forward * Time.deltaTime, Space.World);
        //else this.transform.Translate(this.transform.forward * Time.deltaTime, Space.Self);

        //this.transform.position += Vector3.forward * Time.deltaTime;
        this.transform.position += this.transform.forward * Time.deltaTime;
    }
}
