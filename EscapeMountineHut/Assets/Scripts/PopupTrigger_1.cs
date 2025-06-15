using UnityEngine;

public class PopupTrigger_1 : MonoBehaviour
{
    public GameObject popupPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어가 닿았을 때
        {
            Debug.Log("책상 트리거 발생");
            GameStateManager.Instance.hasVisitedDesk = true;

            if (popupPanel != null)
            {
                popupPanel.SetActive(true); // 팝업 표시
            }
        }
    }
}
