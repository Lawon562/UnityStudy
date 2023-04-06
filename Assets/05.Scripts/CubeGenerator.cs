using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float term = 0f;
    float maxTerm = 2f;
    private void SetTerm(out float variable)
    {
        variable = Mathf.Round(Random.Range(0.6f, maxTerm));
        maxTerm *= 0.998f;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetTerm(out term);
    }
    float timer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > term)
        {
            GameObject cube = Instantiate(obj);
            cube.transform.position = transform.position + new Vector3(0, 1f, -5f + (Random.Range(0,3) * 5f));
            cube.transform.rotation = transform.rotation;
            GameManager.pool.Add(cube);
            timer = 0f;
            SetTerm(out term);
        }
    }
}
