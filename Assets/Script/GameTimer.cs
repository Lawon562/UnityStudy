using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (timer == 0f)
        {
            Debug.Log("Timer 설정 안됨");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f)  return;
        
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            Debug.Log("게임 종료");
        }
    }
}
