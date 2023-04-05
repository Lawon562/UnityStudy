using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum NPC_STATE
//{
//    IDLE, FORWARD, RIGHT, BACK, LEFT
//};

public class NPCControl : MonoBehaviour
{
    [SerializeField]
    private float Speed = 3f;
    //NPC_STATE state;
    //private float CheckTime { get; set; }
    //Vector3 dir = default;

    void Start()
    {
        //state = NPC_STATE.IDLE;
        //CheckTime = 0f;
        //dir = Vector3.zero;
    }

    //private bool TimeCheck(float checkTime)
    //{
    //    return (this.CheckTime >= checkTime);
    //}

    //private void NextState(NPC_STATE State)
    //{
    //    this.state = State;
    //    this.CheckTime = 0;
    //}

    //private void ChangeMovement(float time, NPC_STATE State, Vector3 dir)
    //{
    //    if (TimeCheck(time))
    //    {
    //        NextState(State);
    //        this.dir = dir;
    //    }
    //}

    //private void NPCMove()
    //{
    //    this.CheckTime += Time.deltaTime;

    //    switch (state)
    //    {
    //        case NPC_STATE.IDLE:
    //            ChangeMovement(1f, NPC_STATE.RIGHT, Vector3.right); break;
    //        case NPC_STATE.RIGHT:
    //            ChangeMovement(2f, NPC_STATE.BACK, Vector3.back); break;
    //        case NPC_STATE.BACK:
    //            ChangeMovement(2f, NPC_STATE.LEFT, Vector3.left); break;
    //        case NPC_STATE.LEFT:
    //            ChangeMovement(2f, NPC_STATE.FORWARD, Vector3.forward); break;
    //        case NPC_STATE.FORWARD:
    //            ChangeMovement(2f, NPC_STATE.RIGHT, Vector3.right); break;
    //        default: Debug.Log("ERROR!!"); break;
    //    };
    //    this.transform.Translate(dir * Time.deltaTime * Speed);
    //}

    void Update()
    {
        //NPCMove();
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        this.transform.Translate(Vector3.zero * Time.deltaTime * Speed);
    }
}
