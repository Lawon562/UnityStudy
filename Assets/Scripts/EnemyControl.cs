using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHAR_STATE { IDLE, RECOG, WALK, RUN };

public class EnemyControl : MonoBehaviour
{
    CHAR_STATE mystate = CHAR_STATE.IDLE;
    float processTime = 0f;
    float walkSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        mystate = CHAR_STATE.IDLE;
        processTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CharBehavior();
    }

    private void CharBehavior()
    {
        switch(mystate) 
        {
            case CHAR_STATE.IDLE:  
                idle_process();  
                break;
            case CHAR_STATE.RECOG: 
                recog_process(); 
                break;
            case CHAR_STATE.WALK:  
                walk_process(); 
                break;
            case CHAR_STATE.RUN:   
                run_process(); 
                break;
            default:                
                break;
        }
    }


    private void idle_process() 
    {
        this.processTime += Time.deltaTime;
        if (processTime >= 1f)
        {
            mystate = CHAR_STATE.RECOG;
            processTime = 0f;
        }
    }
    private void recog_process() { mystate = CHAR_STATE.WALK; }
    private void walk_process() 
    {
        Debug.Log("A");
        this.processTime += Time.deltaTime;
        this.transform.Translate(this.transform.forward * Time.deltaTime * walkSpeed, Space.Self);
        if (processTime >= 2f)
        {
            mystate = CHAR_STATE.RUN;
            processTime = 0f;
        }
    }
    private void run_process() { }

}
