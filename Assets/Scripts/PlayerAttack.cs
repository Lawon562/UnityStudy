using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 클릭 시 마우스 포인터 좌표를 알아내어
 * 그 좌표에 있는 Object를 가져와 Enemy인지 비교하고,
 * Enemy라면 EnemyState의
 */
public class PlayerAttack : MonoBehaviour
{
    

    private void ClickProcess()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyState>().Defense( Random.Range(20, 50) );
            }
        }
    }

    private void Update()
    {
        if (TImerController.timer <= 0f) return;
        if (Input.GetMouseButtonDown(0))
        {
            ClickProcess();
        }
        
    }
}
