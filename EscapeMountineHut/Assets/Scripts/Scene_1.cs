using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_1 : MonoBehaviour
{
    public GameObject popupPanel; // "책상을 살펴보자" 메시지 패널

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 문에 닿은 게 플레이어일 때
        {
            if (GameStateManager.Instance.hasVisitedDesk)
            {
                Debug.Log("문에 닿음 - 씬 전환");
                SceneManager.LoadScene("Scene_2"); // 다음 씬 이름
            }
            else
            {
                Debug.Log("책상 먼저 보세요");
                popupPanel.SetActive(true);
            }
        }
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}

