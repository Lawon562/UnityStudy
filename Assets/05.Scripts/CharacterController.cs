using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.LookAt(GameManager.pool[0].transform.position);
            time = 0f;
            animator.SetBool("Attack", false);
            animator.SetBool("Attack", true);
        } else if(time >= 0.6f)
        {
            animator.SetBool("Attack", false);
        }
    }
}
