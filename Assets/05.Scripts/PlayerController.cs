using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float z;
    // Start is called before the first frame update
    public GameObject explosionPrefab;

    public TextMeshProUGUI StatementText;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        z = 0;
    }

    private string[] scoresText = { "Bad", "Slow", "Nice", "Good", "Excellent", "Fast" };
    private int[] scores = { -50, -10, 50, 100, 300, 150 };

    public static bool onStatus = false;
    
    private void Slash(string str)
    {
        Debug.Log(str);
        GameObject obj = GameManager.pool[0];
        GameManager.pool.RemoveAt(0);
        Destroy(obj);
    }
    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 dir = GameManager.pool[0].transform.position - transform.position;
            float direction = dir.magnitude;
            if (direction < 8)
            {
                
                int tmp = (int)Mathf.Round(direction)-2;
                Debug.Log(tmp);
                GameObject obj = GameManager.pool[0];
                if (obj.transform.position.x >= transform.position.x)
                    if (obj.transform.position.z == transform.position.z)
                    {
                        StatementText.text = scoresText[tmp];
                        ScoreText.text = (int.Parse(ScoreText.text) + scores[tmp]).ToString();
                        GameObject explosion = Instantiate(explosionPrefab);
                        explosion.transform.position = obj.transform.position;
                        Destroy(explosion, 2f);
                    }
                    else
                    {
                        StatementText.text = "None";
                        ScoreText.text = (int.Parse(ScoreText.text) - 100).ToString();
                    }
                GameManager.pool.RemoveAt(0);
                
                Destroy(obj);
                
            } 
            else
            {
                StatementText.text = "None";
                ScoreText.text = (int.Parse(ScoreText.text) - 100).ToString();
            }
        }
    }


    public void CharacterMove()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            z -= 5f;
            if (z < -5f) z = -5f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            z += 5f;
            if (z > 5f) z = 5f;
        }

        transform.position = new Vector3(0, 1, z);
    }

}
