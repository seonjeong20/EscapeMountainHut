using UnityEngine;
using UnityEngine.UI;

public class GoalItem : MonoBehaviour
{
    public GameObject clearUI;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowClearPanel);
        clearUI.SetActive(false); // 시작 시 감추기
    }

    void ShowClearPanel()
    {
        clearUI.SetActive(true);
    }
}
