using UnityEngine;

public class PopupTrigger_3 : MonoBehaviour
{
    public GameObject popupPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bookcase2"))
        {
            popupPanel.SetActive(true);
        }
    }
}