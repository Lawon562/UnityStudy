using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    /**
     * Description
     * - Variable for storing the Transform Component value of the Enemy Prefab object
     * Action 
     * - A variable to receive the Enemy Object from the Unity Editor for cloning the Enemy prefab 
     * - Move the cloned Enemy prefab to the FirePoint location.
     */
    [SerializeField]
    private GameObject EnemyPrefab;
    /**
     * Description
     * - A variable for placing Enemy Prefab at a special position
     * 
     * Action
     * - After cloning Enemy Prefab, it is relocated to the position of FirePoint.
     */
    [SerializeField]
    private Vector3 FirePoint;
    /**
     * Description
     * - A variable to storing the monster creation interval
     * 
     * Action
     * - If timer is greater than delayTime, create a monster
     */
    [SerializeField]
    private float delayTime = 1f;
    /**
     * Description
     * - The variable that stores the current time 
     * 
     * Action
     * - If timer is greater than delayTime, create a monster
     * - Reset to current time value(timer)
     */
    private float timer = 0f;

    /**
     * Description
     * - A function that returns a value to make the current time 0f
     * 
     * @return float
     */
    private float TimerReset()
    {
        return 0f;
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            GameObject temp = Instantiate(EnemyPrefab);
            temp.transform.position = FirePoint;
        }
        
    }
    void Start()
    {
        FirePoint = this.transform.position;
        delayTime = 1f;
        timer = TimerReset();

        
        StartCoroutine(CreateEnemy());
    }

    void Update()
    {
        
    }
}
