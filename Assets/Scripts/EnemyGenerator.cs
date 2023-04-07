using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update

    [SerializeField]
    private Transform[] spawnPos;

    public static List<GameObject> enemyList;

    void Start()
    {
        enemyList = new List<GameObject>();
    }
    //float time = 0f;
    // Update is called once per frame
    void Update()
    {
        if(enemyList.Count <= 0) 
        {
            for(int i = 0; i< spawnPos.Length; i++)
            {
                GameObject copy = Instantiate(enemy, spawnPos[i].position, spawnPos[i].rotation) as GameObject;
                copy.name = string.Format("Enemy{0}", i);
                //copy.transform.position = ;
                //copy.transform.rotation = ;
                copy.tag = "Enemy";
                enemyList.Add(copy);
            }
            

        }
    }
}
