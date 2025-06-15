using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 70.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocityY == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.linearVelocityY == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.linearVelocityX);

        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (this.rigid2D.linearVelocityY ==0)
        {
            this.animator.speed = speedx / 2.0f;
        }

        else
        {
            this.animator.speed = 1.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("clear");
        SceneManager.LoadScene("Scene_5");
    }
}
