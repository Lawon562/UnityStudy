using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Slider sliderBgm;
    [SerializeField]
    private Slider sliderSfx;
    // Start is called before the first frame update
    void Start()
    {
        GameData.InitData();
        sliderBgm.value = GameData.BGM_vol;
        sliderSfx.value = GameData.SFX_vol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnPlay()
    {
        Common.NextScene(Key.GameSceneName);
    }

    public void BtnDisableOption()
    {
        PlayerPrefs.SetFloat("BGM_vol", sliderBgm.value);
        PlayerPrefs.SetFloat("SFX_vol", sliderSfx.value);
        GameObject.Find("UIOption").GetComponent<Canvas>().enabled = false;
    }

    public void BtnShowOption()
    {
        GameObject.Find("UIOption").GetComponent<Canvas>().enabled = true;
    }

    public void BtnExitGame()
    {
        Common.GameExit();
    }
}
