using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject startPanel;

    //��ŸƮ ��ư�� �� �޼��带 ����
    public void HideTargetPanel()
    {
        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }
    }
}
