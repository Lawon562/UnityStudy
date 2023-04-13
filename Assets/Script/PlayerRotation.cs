using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public Transform CameraVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float Y = 0f;
    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Rotate(0, CameraVector.right.x * 90, 0);
            //this.transform.
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Rotate(0, CameraVector.right.x * -90, 0);
            //this.transform.
        }
    }
}
