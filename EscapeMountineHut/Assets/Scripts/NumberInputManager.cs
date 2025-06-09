using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class NumberInputManager : MonoBehaviour
{
    public List<Button> numberButtons;// 0~9 버튼 (순서대로 인스펙터에 할당)
    public Button nextButton;// 다음 버튼
    public Button closeButton;// 닫기 버튼
    public GameObject gamePanel;// 전체 게임 패널

    private List<int> correctSequence = new List<int> { 6, 8, 4, 7 };
    private List<int> currentInput = new List<int>();

    private Image panelImage;// GamePanel의 Image 컴포넌트 (색상 깜빡이기용)

    void Start()
    {
        nextButton.gameObject.SetActive(false);// 처음엔 숨기기

        for (int i = 0; i < numberButtons.Count; i++)
        {
            int index = i;// 로컬 변수 캡처
            numberButtons[i].onClick.AddListener(() => OnNumberClicked(index));
        }

        nextButton.onClick.AddListener(LoadNextScene);
        closeButton.onClick.AddListener(CloseGamePanel);

        // GamePanel에 Image 컴포넌트가 있어야 깜빡임 가능
        panelImage = gamePanel.GetComponent<Image>();
        if (panelImage == null)
        {
            Debug.LogWarning("GamePanel에 Image 컴포넌트가 없습니다. 깜빡이기 효과가 동작하지 않습니다.");
        }
    }

    void OnNumberClicked(int number)
    {
        currentInput.Add(number);
        Debug.Log("입력됨: " + number);

        // 입력 길이 초과 시 초기화 + 깜빡임
        if (currentInput.Count > correctSequence.Count)
        {
            currentInput.Clear();
            StartCoroutine(FlashPanelRed());
            Debug.Log("입력초과! 다시 시도");
            return;
        }

        // 정답과 비교
        for (int i = 0; i < currentInput.Count; i++)
        {
            if (currentInput[i] != correctSequence[i])
            {
                currentInput.Clear();
                StartCoroutine(FlashPanelRed());
                Debug.Log("틀림! 다시 시도");
                return;
            }
        }

        // 정답 완료
        if (currentInput.Count == correctSequence.Count)
        {
            Debug.Log("정답!");
            nextButton.gameObject.SetActive(true);
        }
    }

    IEnumerator FlashPanelRed()
    {   
        if (panelImage == null) yield break;

        Color originalColor = panelImage.color;
        Color flashColor = new Color(1f, 0.6f, 0.6f, 1f);

        for (int i = 0; i < 2; i++)
        {
            panelImage.color = flashColor;
            yield return new WaitForSeconds(0.15f);
            panelImage.color = originalColor;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Scene_3");
    }

    public void CloseGamePanel()
    {
        gamePanel.SetActive(false);
    }
}