using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurScore;
    public Text HighScore;

    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        CurScore.text = "Score : " + 0;
        HighScore.text = "Score : " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurScore.text = "Score : " + currentScore;
        HighScore.text = "Score : " + currentScore;
    }
}
