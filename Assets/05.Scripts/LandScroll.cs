using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScroll : MonoBehaviour
{
    public float speed = 3f;
    Vector3 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(firstPos.x, 40f, firstPos.z);
        }
    }
}
