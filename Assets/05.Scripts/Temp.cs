using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp : MonoBehaviour
{
    /*
     * UI의 사용
     * 
     * 일반 객체는 Global 좌표계를 기준으로 하나,
     * 모델들은 Local 좌표계를 삼는다.
     * 
     * UI 요소들은 각자 Local 좌표계를 삼는다.
     * 그런데 UI를 배할 땐 Global 좌표계를 삼을까?
     * 
     * Unity 내의 각각 UI들은 서로 다른 좌표체계를 가집니다.
     * 
     * pxiel -> value 
     * -> 통합하기 위한 객체, canvas : 통합좌표계
     * canvas : GLobal 좌표체계를 가진다.
     * 
     * 
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
