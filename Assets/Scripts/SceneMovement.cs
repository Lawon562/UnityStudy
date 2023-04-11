using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 상호작용을 통해 입력받은 이름의 Scene으로 이동시켜주는 역할
public class SceneMovement : MonoBehaviour
{
    /**
     * 다음 Scene 이름을 저장한다.
     */
    [SerializeField]
    private string NextSceneName;

    /**
     * OnClick 이벤트 버튼
     * 상호작용 시 SceneManager가 NextSceneName에 저장된 이름의 Scene으로 이동시켜줌.
     */
    public void OnClick()
    {
        /** NextSceneName에 저장된 값이 없을 때 에러 방지 **/
        if (NextSceneName != null)
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
