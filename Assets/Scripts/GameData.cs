using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GameData
{
    public static int m_stage = 1;
    public static int m_Coin = 0;

    // 기지 기준 데이터
    public static int killCount = 0;

    public static float BGM_vol = 1f;
    public static float SFX_vol = 1f;

    public static bool isPauseState = false;

    public static float m_baseLife = 10;
    public static float m_max_enemym = 10;


    public static void InitData()
    {
        isPauseState = false;
        BGM_vol = PlayerPrefs.GetFloat("BGM_vol", 1f);
        SFX_vol = PlayerPrefs.GetFloat("SFX_vol", 1f);

    }
    //public void Change_value
}
