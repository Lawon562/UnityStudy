using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMaker : MonoBehaviour
{
    public Transform EnemyInfo;
    public Transform SpawnPoint;

    int curnum = 0;
    int maxnum = 5;
    float maketime = 0;
    // Start is called before the first frame update
    void Start()
    {
        curnum = 0;
        maxnum = 5;
        maketime = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        MakeEnemy();
    }

    void MakeEnemy()
    {
        if(curnum < maxnum) maketime += Time.deltaTime;
        if (maketime >= 1f && curnum < maxnum)
        {
            curnum++;
            Instantiate(EnemyInfo, SpawnPoint.position, SpawnPoint.rotation);
            maketime = 0f;
        }
    }
}
