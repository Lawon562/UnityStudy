using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text txt_val1;

    [SerializeField] 
    private Text txt_val2;

    [SerializeField]
    private Button btn_ok;

    [SerializeField]
    private Slider val_slider;

    private const string INITIAL_STRING = "0";

    // Start is called before the first frame update
    void Start()
    {
        txt_val1.text = INITIAL_STRING;
        txt_val2.text = INITIAL_STRING;
        btn_ok.interactable = true;
    }

    public void ButtonOnClick()
    {
        txt_val1.text = "Clicked";
        if(val_slider.value < 1000)
        {
            btn_ok.interactable = true;
        }

        
    }

    
    public void SlideMove()
    {
        txt_val2.text = string.Format("{0:f0}", val_slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (val_slider.value < 1000)
        {
            val_slider.value += 999 * Time.deltaTime * 0.3f;
        }
        
    }
}
