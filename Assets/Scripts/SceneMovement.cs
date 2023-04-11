using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ��ȣ�ۿ��� ���� �Է¹��� �̸��� Scene���� �̵������ִ� ����
public class SceneMovement : MonoBehaviour
{
    /**
     * ���� Scene �̸��� �����Ѵ�.
     */
    [SerializeField]
    private string NextSceneName;

    /**
     * OnClick �̺�Ʈ ��ư
     * ��ȣ�ۿ� �� SceneManager�� NextSceneName�� ����� �̸��� Scene���� �̵�������.
     */
    public void OnClick()
    {
        /** NextSceneName�� ����� ���� ���� �� ���� ���� **/
        if (NextSceneName != null)
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
