using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    public static List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
