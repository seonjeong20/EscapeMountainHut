using UnityEngine;

public class PopupTrigger_1 : MonoBehaviour
{
    public GameObject popupPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Desk"))
        {
            popupPanel.SetActive(true);
        }
    }
}
