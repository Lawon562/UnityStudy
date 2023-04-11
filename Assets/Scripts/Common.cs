using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Common
{
    public static void NextScene(string NextSceneName)
    {
        SceneManager.LoadScene(NextSceneName);
    }

    public static void GameExit()
    {
        // 전처리기: 코드 중 키워드 찾기
#if UNITY_EDITOR
        /** PC Unity 실행 중 정지 */
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
            Application.Quit();
#elif UNITY_IOS
            Application.Quit();
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // 다른 방법
#else
            /** Android, iPhone, quest - 스마트폰 베이스 */
            Application.Quit();
#endif
    }
}
