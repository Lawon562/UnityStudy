using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour
{

    public void BtnTry()
    {
        Common.NextScene(Key.GameSceneName);
    }

    public void BtnGoTitle()
    {
        Common.NextScene(Key.TitleSceneName);
    }

    public void BtnExitGame()
    {
        Common.GameExit();
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
