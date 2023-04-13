using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Profiling.Memory.Experimental;
using System.Runtime.InteropServices.ComTypes;
using UnityEditorInternal;

public enum GAME_STATE { INIT, READY, GO, PLAY, FAILED, CLEAR, MARKET }

public class GameManager : MonoBehaviour
{
    GAME_STATE gState;
    public Transform SpawnPos;
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject BloodEffect;

    public static List<GameObject> zombieList;

    public Text CreditText;
    public Text StageText;
    public Slider MyHpSlider;
    public GameObject FailScene;


    private float zombieTime= 0f;
    // Start is called before the first frame update
    void Start()
    {
        StageText.text = "Stage : " + GameData.m_stage;
        gState = GAME_STATE.INIT;
        zombieList = new List<GameObject>();
        GameData.m_baseLife = 10f;
        MyHpSlider.maxValue = GameData.m_baseLife;

    }

    public void OnClick()
    {
        SceneManager.LoadScene(Key.OverSceneName);
    }
    int count = 0;
    
    public IEnumerator CreateEnemy()
    {
        isMake = true;
        yield return new WaitForSeconds(2f);
        GameObject copy = Instantiate(zombie, SpawnPos.position, SpawnPos.rotation);
        zombieList.Add(copy);
        copy.transform.position += new Vector3(0,0,Random.Range(-6,6));
    }
    float curCount_e = 0;
    public void GameRule()
    {
        switch (gState)
        {
            case GAME_STATE.PLAY:
                if (GameData.m_baseLife <= 0)
                {
                    GameData.m_baseLife = 100;
                    curCount_e = 0;
                    GameData.killCount = 0;
                    SceneManager.LoadScene(Key.OverSceneName);
                }
                if (GameData.killCount >= curCount_e)
                {
                    curCount_e = 0;
                    GameData.killCount = 0;
                    SceneManager.LoadScene(Key.ClearSceneName);
                    
                }
                break;

        }
    }

    public void GameFlow()
    {
        switch (gState)
        {
            case GAME_STATE.INIT:
                gState = GAME_STATE.PLAY;
                break;
            case GAME_STATE.PLAY:
                if (count > 10)
                {
                    if (MyHpSlider.value <= 0) gState = GAME_STATE.FAILED;
                    else if (MyHpSlider.value > 0 && count == 0) gState = GAME_STATE.CLEAR;
                    return;
                }
                zombieTime += Time.deltaTime;
                if (zombieTime > 2f)
                {
                    isMake = false;
                    zombieTime = 0f;
                }
                if (isMake == false && zombieList.Count <= 10)
                {
                    StartCoroutine(CreateEnemy());
                    count = zombieList.Count;
                }
                break;
        }
    }
    bool isMake = false;
    // Update is called once per frame
    void Update()
    {
        CreditText.text = "Credit : " + GameData.m_Coin;
        
        MyHpSlider.value = GameData.m_baseLife;
        GameFlow();
        if (GameData.m_baseLife <= 0)
        {
            FailScene.GetComponent<Canvas>().enabled = true;
            return;
        }

        

        CharRecog();    // 적군 인지 및 공격        
    }

    

    private void CharRecog()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(screenRay, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
#if UNITY_ANDROID
                    HandHeld.Vibrate();
#endif

                    //hit.collider.GetComponent<ZombieController>().BeAttacked(0.5f);
                    hit.collider.SendMessage("BeAttacked", 0.5f);
                    //Destroy(hit.transform.gameObject);
                    Debug.Log("좌표" + hit.point);
                    Instantiate(BloodEffect, hit.point, Quaternion.identity);
                }

            }
        }
    }
}
