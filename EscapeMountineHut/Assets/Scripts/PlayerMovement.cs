using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isJumping = false;
    private bool isGrounded = false;
    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 방향 입력 받기
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;

        // 지면 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 점프 입력
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
        }

        // 점프 종료 체크
        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            isJumping = false;
        }

        // 애니메이션 파라미터 설정
        animator.SetFloat("Speed", moveDir.magnitude);
        animator.SetBool("IsJumping", isJumping);
    }

    void FixedUpdate()
    {
        // 상하좌우 자유 이동 (점프 중 Y는 유지)
        Vector2 velocity = rb.linearVelocity;

        velocity.x = moveDir.x * moveSpeed;

        // 점프 중이 아닐 때만 수직 이동
        if (!isJumping )
        {
            velocity.y = moveDir.y * moveSpeed;
        }

        rb.linearVelocity = velocity;
    }
}