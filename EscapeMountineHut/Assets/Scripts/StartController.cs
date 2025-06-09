using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject startPanel;

    //스타트 버튼에 이 메서드를 연결
    public void HideTargetPanel()
    {
        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }
    }
}
