using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public string triggerName; // 예: "Desk"
    public SubtitleManager subtitleManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("desk");
            subtitleManager.StartSubtitleByTrigger(triggerName);
        }
    }
}