using UnityEngine;

public class PopupTrigger_2 : MonoBehaviour
{
    public GameObject popupPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bookcase1"))
        {
            popupPanel.SetActive(true);
        }
    }
}
