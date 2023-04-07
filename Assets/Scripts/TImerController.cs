using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TImerController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI TimeText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;
    public static int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static float timer = 60f;
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f) return;
        timer -= Time.deltaTime;
        TimeText.text = string.Format("{0:F1}", timer);
        
        ScoreText.text = string.Format("{0}", Score);
    }
}
