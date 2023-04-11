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
        // ��ó����: �ڵ� �� Ű���� ã��
#if UNITY_EDITOR
        /** PC Unity ���� �� ���� */
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
            Application.Quit();
#elif UNITY_IOS
            Application.Quit();
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // �ٸ� ���
#else
            /** Android, iPhone, quest - ����Ʈ�� ���̽� */
            Application.Quit();
#endif
    }
}
