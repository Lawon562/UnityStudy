using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_STATE { IDLE, PATROL, CHASE, FAILED }

public class ChasingEnemy : MonoBehaviour
{
    /**
     * TargetObject : Enemy�� ����ٴ� Object�� Transform
     */
    [SerializeField]
    private Transform TargetObject;

    /**
     * PatrolPosition : Enemy�� Patrol �߿� �ݵ�� �鷯�� �� ��ġ �迭
     */
    [SerializeField]
    private Transform[] PatrolPosition;

    /**
     *  recognitionDistance : Enemy�� �ν��� �� �ִ� �ִ� �Ÿ��� ����
     */
    private const float recognitionDistance = 20f;

    /**
     * NavMeshAgent : ��ã�� Agent
     * enemyState : Enemy�� ���¸� �����ص� ����
     */
    private NavMeshAgent agent;
    private ENEMY_STATE enemyState;

    /**
     * distance : TargetObject�� Enemy���� �Ÿ��� �����ص� ����
     */
    private float distance = 0f;

    /**
     * target : ��Ʈ���ؾ��ϴ� Position�� �� ��°���� �����ϴ� ����
     * actionTimer : ��ü�� ���¸� �ٲ� �� ����ϴ� Ÿ�̸� ����
     * 
     */
    int PatrolPositionNumber = 0;
    float actionTimer = 0f;

    /**
     * Start�Լ� ����
     *  - enemyState�� �ʱ�ȭ(IDLE)
     *  - agent component ����
     */
    void Start()
    {
        enemyState = ENEMY_STATE.IDLE;
        agent = GetComponent<NavMeshAgent>();
    }

    
    /**
     * GetDistance
     *  - ���� ��ü���� Target ��ü���� �Ÿ��� ��ȯ�ϴ� �Լ�
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
     *  - �� ��ü �� �Ÿ��� ���Ͽ� ENEMY�� �ִ��Ÿ����� ª���� ENEMY_STATE�� CHASE����, PATROL���� ��ȯ�ϴ� �Լ�
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
     *  - CheckDistance�� �˾Ƴ� ENEMY_STATE�� ����, CHASE�� TargetObject�� �����ϰ�
     *  �׷��� ������ ��θ� �ʱ�ȭ �� FAILED�� �ٲ۴�.
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
     *  - actionTimer�� ���� �ð����� ��ٸ� ��, ���޹��� ENEMY_STATE�� ���� �׼� ���¸� �������ִ� �Լ�
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
     *  - �� ��° ��ġ�� Patrol���� �����Ѵ�.
     *  - ���� ��ü�� Patrol�� ��ü�� ��ġ�� �Ÿ��� ���Ѵ�.
     *  - �Ÿ��� 1���� ������, PatrolPositionNumber�� 1�� �ø��µ�, 
     *  ���� PatrolPosition�迭�� ���̺��� ������� �ٽ� 0���� �����Ѵ�.
     *  - Enemy�� ���¸� enemyState�� �������Ѵ�.
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
     *  - Enemy�� ���¿� ���� �ൿ�� �ٲ��ִ� �Լ�
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
     *  - Enemy�� �ν��ϴ� ������ Gizmos(������ ��)�� �׷���
     * 
     * @return void
     */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, recognitionDistance);
    }
}
