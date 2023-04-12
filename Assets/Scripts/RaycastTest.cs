using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;



public class RaycastTest : MonoBehaviour
{
    public Transform firePoint;
    float timer;
    bool attackFlag = false;

    RaycastHit hit;
    //List<float> timers;
    //Dictionary<RaycastHit, float> hitList;

    float dir_x, dir_y;
    float speed = 3f;
    

    public struct hitObject
    {
        public GameObject hit;
        public float timer;

        public hitObject(GameObject _hit, float _timer)
        {
            this.hit = _hit;
            this.timer = _timer;
        }
    }

    public List<hitObject> hitList;

    // Start is called before the first frame update
    void Start()
    {
        hitList = new List<hitObject>();
        //timers = new List<float>();
        //hitList = new Dictionary<RaycastHit, float>();
    }

    // Update is called once per frame
    void Update()
    {
        CharMove();
        CharRecog();
    }

    


    private void CharRecog()
    {
        /**
         * 스페이스 키가 눌리면 Ray 발사.(15미터)
         *   - 만약 Ray가 오브젝트와 충돌했다면 충돌한 오브젝트 색상 변경(red), LinRender enabled, 공격 플래그 올림
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 15f))
            {
                if(hit.collider != null)
                {
                    hitList.Add(new hitObject(hit.collider.gameObject, 0f));
                    hit.collider.GetComponent<Renderer>().material.color = Color.red;
                    GetComponent<LineRenderer>().enabled = true;
                    attackFlag = true;
                }
            }
        }
        /**
         * 공격 플래그가 올라가고 0.2초가 지나면 
         *  - 충돌한 오브젝트의 머테리얼 색상을 white로 변경.
         *  - LineRenderer 끄기
         *  - 타이머 초기화 및 공격 플래그 내리기
         */
        if (attackFlag)
        {
            for (int i = 0; i < hitList.Count; i++)
            {
                hitObject h = hitList[i];
                h.timer += Time.deltaTime;
                hitList[i] = h;
            }
            
            if (hitList.Count > 0 && hitList[0].timer >= 0.2f)
            {
                hitList[0].hit.GetComponent<Renderer>().material.color = Color.white;
                GetComponent<LineRenderer>().enabled = false;
                hitList.RemoveAt(0);
                if (hitList.Count == 0) attackFlag = false;
            }
        }
        


    }

    private void CharMove()
    {
        dir_x = Input.GetAxis("Horizontal");
        dir_y = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.right * Time.deltaTime * speed * dir_x);
        this.transform.Translate(Vector3.up * Time.deltaTime * speed * dir_y);
    }
}
