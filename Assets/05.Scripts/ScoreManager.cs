using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurScore;
    public Text HighScore;

    public int currentScore;
    public int highScore = 0;
    public static bool Playable = true;


    private const string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        currentScore = 0;
        CurScore.text = "Score : " + 0;
        HighScore.text = "High Score : " + highScore;
    }

    private void ShowUI()
    {
        CurScore.text = "Score : " + currentScore;
        HighScore.text = "High Score : " + highScore;

    }

    public void StoreScore()
    {
        if (highScore < currentScore) PlayerPrefs.SetInt(highScoreKey, currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(Playable)
        {
            ShowUI();
        }
        else 
        {
            StoreScore();
        }
    }
}
