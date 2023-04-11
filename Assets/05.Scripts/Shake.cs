using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Shake : MonoBehaviour
{
    float totalTimer = 0f;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        totalTimer = 0f;
        time = 0f;
    }

    public static void Play()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        totalTimer += Time.deltaTime;
        if (totalTimer < 1f)
        {
            time += Time.deltaTime;
            if (time > 0.05f)
            {
                transform.position = new Vector3(Random.Range(-0.15f, 0.15f), 1, -10);
                time = 0f;
            }
        }else
        {
            this.enabled = false;
            totalTimer = 0f;
            time = 0f;
            transform.position = new Vector3(0, 1, -10);

        }


    }
}
