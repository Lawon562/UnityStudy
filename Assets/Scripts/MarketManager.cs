using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public Text val_coin;
    public Text val_repair;
    public Text val_upgrade;
    public Button Repair;
    public Button Upgrade;

    public int repair;
    public int upgrade;

    public void ShowMarkektInfo()
    {
        val_coin.text = "Credit : " + GameData.m_Coin;
        val_repair.text = "Repair : " + repair;
        val_upgrade.text = "Upgrade : " + upgrade;
    }

    public void SetMarketInfo()
    {

    }

    public void BtnPlay()
    {
        Common.NextScene(Key.GameSceneName);
    }

    public void BtnUpgrade()
    {

    }

    public void BtnRepair()
    {

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
