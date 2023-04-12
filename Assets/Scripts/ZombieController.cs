using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{

    ACTION_TYPE actionType;

    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float m_life = 1f;
    [SerializeField]
    private float m_attpower;

    public GameObject DeathParticle;
    public GameObject BeAttackParticle;
    public GameObject AttackParticle;
    public GameObject HpUI;
    bool attack = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
        m_life = 0.6f + (0.4f * GameData.m_stage);
        m_attpower = 0.4f + (0.2f* GameData.m_stage);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAction();
    }

    private void SwitchAnimation(String offAnim, String onAnim)
    {
        animator.SetBool(offAnim, false);
        animator.SetBool(onAnim, true);
    }

    private void CreateParticle(GameObject particle)
    {
        GameObject copyObj= Instantiate(particle, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(copyObj, copyObj.GetComponent<ParticleSystem>().main.duration);
    }

    private void ChangeAction(ACTION_TYPE action)
    {
        actionType = action;
        actionTime = 0f;
    }
    private void ChangeAction(ACTION_TYPE action, float speed)
    {
        this.actionType = action;
        this.actionTime = 0f;
        this.speed = speed;
    }


    IEnumerator BaseLineAttack()
    {
        attack = true;
        yield return new WaitForSeconds(0.6f);
        GameData.m_baseLife -= this.m_attpower;

    }

    float actionTime;
    private void EnemyAction()
    {
        switch(actionType)
        {
            case ACTION_TYPE.INIT:
                actionType = ACTION_TYPE.IDLE; 
                break;
            case ACTION_TYPE.IDLE:
                actionTime += Time.deltaTime;
                if(actionTime > 0.5f)
                {
                    ChangeAction(ACTION_TYPE.WALK, speed: 2f);
                }
                break;
            case ACTION_TYPE.WALK:
                CharMove();
                this.GetComponentInChildren<Animator>().SetBool("Walk", true);
                actionTime += Time.deltaTime;
                if (actionTime > 3f)
                {
                    ChangeAction(ACTION_TYPE.RUN, speed: 6f);
                }
                break;
            case ACTION_TYPE.RUN:
                CharMove();
                SwitchAnimation(offAnim:"Walk", onAnim:"Run");
                break;
            case ACTION_TYPE.CONTACT:
                SwitchAnimation(offAnim: "Run", onAnim: "Idle");
                actionTime += Time.deltaTime;
                
                if (actionTime > 1f)
                {
                    ChangeAction(ACTION_TYPE.ATTACK, speed: 0f);
                }
                break;
            case ACTION_TYPE.ATTACK:
                actionTime += Time.deltaTime;
                SwitchAnimation(offAnim: "Idle", onAnim: "Attack");
                if (!attack)
                {
                    //StartCoroutine("BaseLineAttack");
                }
                if (actionTime > 1f)
                {
                    GameData.m_baseLife -= m_attpower;
                    ChangeAction(ACTION_TYPE.COOLTIME);
                }
                break;
            case ACTION_TYPE.COOLTIME:
                actionTime += Time.deltaTime;
                SwitchAnimation(offAnim: "Attack", onAnim: "Idle");
                if (actionTime > 2f)
                {
                    ChangeAction(ACTION_TYPE.ATTACK);
                }
                break;

        }
    }

    public void BeAttacked(float amount)
    {
        if (m_life <= 0) return;

        this.m_life -= amount;
        HpUI.GetComponent<Slider>().value = m_life;

        CreateParticle(BeAttackParticle);

        if (m_life <= 0)
        {
            GameData.m_Coin+= 50 + (50 * GameData.m_stage);
            CreateParticle(DeathParticle);
            Destroy(this.gameObject);
            GameManager.zombieList.Remove(this.gameObject);
            return;
        }
    }

    
    void CharMove()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * GameData.m_stage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BaseStation")
        {
            actionType = ACTION_TYPE.CONTACT;
            this.GetComponent<Rigidbody>().isKinematic = true;
         //   transform.Find("TT_demo_zombie").GetComponent<Animator>().SetBool("Attack", true);
        }
    }
}
