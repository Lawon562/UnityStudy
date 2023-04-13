using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_STATE { IDLE, PATROL, CHASE, FAILED }

public class ChasingEnemy : MonoBehaviour
{
    /**
     * TargetObject : Enemy가 따라다닐 Object의 Transform
     */
    [SerializeField]
    private Transform TargetObject;

    /**
     * PatrolPosition : Enemy가 Patrol 중에 반드시 들러야 할 위치 배열
     */
    [SerializeField]
    private Transform[] PatrolPosition;

    /**
     *  recognitionDistance : Enemy가 인식할 수 있는 최대 거리를 저장
     */
    private const float recognitionDistance = 20f;

    /**
     * NavMeshAgent : 길찾기 Agent
     * enemyState : Enemy의 상태를 저장해둘 변수
     */
    private NavMeshAgent agent;
    private ENEMY_STATE enemyState;

    /**
     * distance : TargetObject와 Enemy간의 거리를 저장해둘 변수
     */
    private float distance = 0f;

    /**
     * target : 패트롤해야하는 Position이 몇 번째인지 저장하는 변수
     * actionTimer : 객체의 상태를 바꿀 때 사용하는 타이머 변수
     * 
     */
    int PatrolPositionNumber = 0;
    float actionTimer = 0f;

    /**
     * Start함수 역할
     *  - enemyState를 초기화(IDLE)
     *  - agent component 연결
     */
    void Start()
    {
        enemyState = ENEMY_STATE.IDLE;
        agent = GetComponent<NavMeshAgent>();
    }

    
    /**
     * GetDistance
     *  - 현재 객체에서 Target 객체까지 거리를 반환하는 함수
     *  
     *  @param Transform Target
     *  @return float
     */
    private float GetDistance(Transform Target)
    {
        //return (this.transform.position - m_gameObject.position).magnitude;
        return Vector3.Distance(this.transform.position, TargetObject.position);
    }

    /**
     * CheckDistance
     *  - 두 객체 간 거리를 비교하여 ENEMY의 최대사거리보다 짧으면 ENEMY_STATE가 CHASE인지, PATROL인지 반환하는 함수
     * 
     * @param Transform Target
     * @return ENEMY_STATE
     */
    private ENEMY_STATE CheckDistance(Transform Target)
    {
        return GetDistance(Target) < recognitionDistance ? ENEMY_STATE.CHASE : ENEMY_STATE.PATROL;
    }

    /**
     * Chase 
     *  - CheckDistance로 알아낸 ENEMY_STATE에 따라, CHASE면 TargetObject를 추적하고
     *  그렇지 않으면 경로를 초기화 후 FAILED로 바꾼다.
     * 
     * @return void
     */
    private void Chase()
    {
        if (CheckDistance(TargetObject)== ENEMY_STATE.CHASE)
        {
            agent.SetDestination(TargetObject.position);
        }
        else
        {
            agent.ResetPath();
            enemyState = ENEMY_STATE.FAILED;
        }
    }

    
    /**
     * ChangeEnemyState
     *  - actionTimer로 제한 시간까지 기다린 후, 전달받은 ENEMY_STATE로 현재 액션 상태를 변경해주는 함수
     *  
     *  @return void
     */
    private void ChangeEnemyState(float limitTime, ENEMY_STATE state)
    {
        actionTimer += Time.deltaTime;
        if (actionTimer > limitTime)
        {
            actionTimer = 0f;
            enemyState = state;
        }
    }

    /**
     * Patrol
     *  - 몇 번째 위치로 Patrol할지 설정한다.
     *  - 현재 객체와 Patrol할 객체의 위치간 거리를 구한다.
     *  - 거리가 1보다 작으면, PatrolPositionNumber를 1씩 올리는데, 
     *  만약 PatrolPosition배열의 길이보다 길어지면 다시 0으로 설정한다.
     *  - Enemy의 상태를 enemyState에 재저장한다.
     */
    private void Patrol()
    {
        agent.SetDestination(PatrolPosition[PatrolPositionNumber].position);
        float posDistance = Vector3.Distance(this.transform.position, PatrolPosition[PatrolPositionNumber].position);
        if (posDistance < 1f) PatrolPositionNumber++;
        if (PatrolPositionNumber == PatrolPosition.Length) PatrolPositionNumber = 0;

        enemyState = CheckDistance(TargetObject);
    }

    /**
     * Enemy
     *  - Enemy의 상태에 따라 행동을 바꿔주는 함수
     * 
     * @return void
     */
    private void Enemy()
    {
        switch (enemyState)
        {
            case ENEMY_STATE.IDLE:      ChangeEnemyState(3f, ENEMY_STATE.PATROL);   break;
            case ENEMY_STATE.PATROL:    Patrol();                                   break;
            case ENEMY_STATE.CHASE:     Chase();                                    break;
            case ENEMY_STATE.FAILED:
                enemyState = GetDistance(TargetObject) < recognitionDistance ? ENEMY_STATE.CHASE : ENEMY_STATE.FAILED;
                ChangeEnemyState(3f, ENEMY_STATE.PATROL);
                break;
            default:
                Debug.Log("Error!!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Enemy();
    }

    /**
     * OnDrawGizmos
     *  - Enemy가 인식하는 공간을 Gizmos(빨간색 원)로 그려줌
     * 
     * @return void
     */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, recognitionDistance);
    }
}
