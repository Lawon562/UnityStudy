using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Profiling.Memory.Experimental;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPos;
    [SerializeField]
    private GameObject zombie;

    private float zombieTime= 0f;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    public IEnumerator CreateEnemy()
    {
        isMake = true;
        yield return new WaitForSeconds(2f);
        GameObject copy = Instantiate(zombie, SpawnPos.position, SpawnPos.rotation);
        copy.transform.position += new Vector3(0,0,Random.Range(-6,6));
    }

    //public void CreateEnemy()
    //{
    //    Instantiate(zombie, SpawnPos.position, SpawnPos.rotation);
    //}
    bool isMake = false;
    // Update is called once per frame
    void Update()
    {
        zombieTime += Time.deltaTime;
        if(zombieTime > 2f)
        {
            isMake = false;
            zombieTime = 0f;
        }
        if(isMake == false)
        {
            StartCoroutine(CreateEnemy());
        }
    }
}
