using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BallCopy : MonoBehaviour
{
    [SerializeField]
    private GameObject RealBall;

    [SerializeField]
    private GameObject FraudBall;

    [SerializeField]
    private int MaxBallCount;

    [SerializeField]
    private Renderer Ground;

    [SerializeField]
    private Renderer MaxHeight;



    private List<bool> balls;



    //NavMeshAgent agent;


    void Start()
    {
        
        if (MaxBallCount == 0) MaxBallCount = 30;

        //agent = GetComponent<NavMeshAgent>();  

        SetBallList();

        Invoke("BallRandomPosition", 0.2f);



    }

    private void BallRandomPosition()
    {
        Vector3 plainSize = Ground.bounds.size;
        float width = plainSize.x;
        float depth = plainSize.z; // 깊이 길이

        Vector3 maxHeightSize = MaxHeight.bounds.size;
        float height = maxHeightSize.y;
        for (int i = 0; i < balls.Count; i++)
        {
            GameObject copy;
            if (balls[i])
            {
                copy = Instantiate(RealBall);
            }
            else
            {
                copy = Instantiate(FraudBall);
            }

            NavMeshHit hit;
            /*
            Vector3 position = new Vector3(
                Random.Range(-25f, 25f),
                Random.Range(0, 10f),//Random.Range(-25f, 25f),
                Random.Range(-25f, 25f)
                );
            */
            
            
            Vector3 position = new Vector3(
                Random.Range((width/2 * -1), (width/2)),
                Random.Range(0, 10f),
                Random.Range((depth / 2 * -1), (depth / 2))
            );
            if (NavMesh.SamplePosition(position, out hit, 10.0f, NavMesh.AllAreas))
            {
                copy.GetComponent<NavMeshAgent>().Warp(hit.position); // 유효한 NavMesh 위치로 에이전트 이동
            }

        }
    }


    private void SetBallList()
    {
        balls = new List<bool>();
        for (int i = 0; i < MaxBallCount; i++) balls.Add(false);
        balls[Random.Range(0, MaxBallCount-1)] = true;
    }

    void Update()
    {
        
    }
}
