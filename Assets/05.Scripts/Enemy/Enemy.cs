using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp = 100;

    [SerializeField]
    private float Speed = 5f;

    [SerializeField]
    private const int randomMin =  0;

    [SerializeField]
    private const int randomMax =  100;

    [SerializeField]
    private const int guidedPercentage = 30;

    private Vector3 dir = Vector3.down;

    public int GetRandom()
    {
        return Random.Range(randomMin, randomMax);
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetDir;
       // if (GetRandom() <= guidedPercentage)
        //{
            GameObject target = GameObject.Find("Player");
            if(target != null )
            {
                targetDir = target.transform.position - this.transform.position;
                targetDir.Normalize();
                //Vector3.Distance(target.transform.position, this.transform.position);
                dir = targetDir;
            }
        //}
        //else
        //{
         //   dir = Vector3.down;
        //}
    }


    // Update is called once per frame
    void Update()
    {
        
        this.transform.position += dir * Time.deltaTime * Speed;
    }
    [SerializeField]
    private GameObject particle;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        if (Hp <= 0) return;
        Hp -= 50;
        if (Hp <= 0)
        {
            GameObject obj = Instantiate(this.particle);
            obj.transform.position = this.transform.position;
            Camera.main.GetComponent<Shake>().enabled = true;
            GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore++;
            Destroy(obj, 1f);
            // Vector3 dir = Vector3.down;
            Destroy(this.gameObject);   // 현재 객체 삭제
            // Destroy(base.gameObject);   // 현재 객체의 상위 객체를 삭제  
        }
        
    }
}
