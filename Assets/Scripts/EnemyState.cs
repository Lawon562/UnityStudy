using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{
    public float Hp = 100f;
    
    public float Defense(float amount)
    {
        if (Hp <= 0) return 0;
        this.Hp -= amount;
        Transform hpBar = this.transform.Find("Canvas");
        Canvas canvas = transform.GetComponentInChildren<Canvas>();
        canvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.Hp/100);
        

        if (Hp <= 0)
        {
            EnemyGenerator.enemyList.Remove(this.gameObject);
            Debug.Log(EnemyGenerator.enemyList.Count);
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-360, -360), 90, Random.Range(0, 360)));
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            TImerController.Score++;
            Destroy(this.gameObject, 1f);
            return 0;
        }

        return this.Hp;
    }

    private void OnDestroy()
    {
        
    }

}
