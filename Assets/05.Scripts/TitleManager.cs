using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        nextTime = 0f;
    }
    [SerializeField]
    private string LoadSceneName;
    public void Enter_UIScene()
    {
        SceneManager.LoadScene(LoadSceneName);
    }
    float nextTime = 0;
    // Update is called once per frame
    void Update()
    {
        nextTime += Time.deltaTime;
        if (nextTime > 5f)
        {
            nextTime = 0f;
            Enter_UIScene();
        }
    }
}
