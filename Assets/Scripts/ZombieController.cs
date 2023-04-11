using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed = 1.5f;
    public float m_life = 1f;
    public float m_attpower;
    // Start is called before the first frame update
    void Start()
    {
        m_life = 0.6f * GameData.m_stage;
        m_attpower = 0.4f * GameData.m_stage;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attack)
        {
            CharMove();
        }
    }

    
    void CharMove()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * GameData.m_stage);
    }

    bool attack = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "BaseStation") 
        {
            attack = true;
            transform.Find("TT_demo_zombie").GetComponent<Animator>().SetBool("Attack", true);
        }
    }
}
