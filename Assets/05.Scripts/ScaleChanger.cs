using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time;
    float y = 0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 0.2f)
        {
            y += 0.02f;
            if (y > 1.2f) y = 1.2f;
            
        }
        else if (time < 0.4f)
        {
            y -= 0.02f;
            if (y < 1f) y = 1f;
        }
        else
        {
            time = 0f;
        }
        this.transform.localScale = new Vector3(1f, y, 1f);

    }
}
