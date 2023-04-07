using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    private static ClickerManager instance;
    public static ClickerManager GetInstance
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


    [SerializeField]
    private Text coinText;

    StringBuilder coinPlus = new StringBuilder("");
    static ulong coin = 0;
    private ulong getCoin = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        
    }

    

    private ulong GetCoin()
    {
        return getCoin;
    }

    

    private void a()
    {
        if (coin >= 10000)
        {
            
        }
    }


    public void OnClick()
    {
        coin += getCoin;
        coinText.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
