using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransitionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            Debug.Log("문에 닿음 - 씬 전환");
            SceneManager.LoadScene("Scene_2");
        }
    }

}
