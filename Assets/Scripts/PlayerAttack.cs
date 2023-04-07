using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
