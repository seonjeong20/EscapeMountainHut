using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LockerDoor : MonoBehaviour
{
    public GameObject contentImage;   // 내용물 오브젝트 (없을 수도 있음)
    private Image doorImage;          // 문 이미지
    private Button doorButton;        // 문 버튼

    public float reopenDelay = 2f;

    void Start()
    {
        doorButton = GetComponent<Button>();
        doorImage = GetComponent<Image>();

        doorButton.onClick.AddListener(OpenDoor);

        if (contentImage != null)
            contentImage.SetActive(false);
    }

    void OpenDoor()
    {
        doorImage.enabled = false;
        doorButton.interactable = false;

        if (contentImage != null)
            contentImage.SetActive(true);

        StartCoroutine(ReopenDoorAfterDelay());
    }

    IEnumerator ReopenDoorAfterDelay()
    {
        yield return new WaitForSeconds(reopenDelay);

        doorImage.enabled = true;
        doorButton.interactable = true;

        if (contentImage != null)
            contentImage.SetActive(false);
    }
}

