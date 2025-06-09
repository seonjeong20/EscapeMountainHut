using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 방향 입력 받기 (A/D 또는 좌/우 키, W/S 또는 상/하 키)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;

        // 좌우 방향 전환
        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 (X축 반전)
        }

        // 애니메이션 파라미터 설정
        animator.SetFloat("Speed", moveDir.magnitude);
    }

    void FixedUpdate()
    {
        // 상하좌우 자유 이동
        Vector2 velocity = new Vector2(
            moveDir.x * moveSpeed,
            moveDir.y * moveSpeed
        );

        rb.linearVelocity = velocity; // linearVelocity → velocity로 수정
    }
}
