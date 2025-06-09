using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene_3 : MonoBehaviour
{
    public GameObject popupObject; // 씬 전환 전에 활성화할 오브젝트 (예: 알림창, 텍스트 등)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door2"))
        {
            Debug.Log("문에 닿음 - 씬 전환 준비");
            popupObject.SetActive(true); // 오브젝트 먼저 활성화
            StartCoroutine(DelayedSceneLoad(2f)); // 2초 후 씬 전환
        }
    }

    private IEnumerator DelayedSceneLoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Scene_4");
    }
}

