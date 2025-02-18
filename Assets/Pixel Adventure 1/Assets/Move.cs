using UnityEngine;

public class Move : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float moveSpeed = 5f; // Tốc độ di chuyển

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Kiểm tra di chuyển trái/phải
        float move = Input.GetAxis("Horizontal"); // Lấy giá trị từ -1 đến 1 khi nhấn các phím A/D hoặc mũi tên
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y); // Thay đổi vận tốc nhân vật

        // Bật/tắt hoạt ảnh chạy
        if (move != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Kiểm tra nhảy
        if (Input.GetKeyDown(KeyCode.UpArrow) && animator.GetBool("isJumping") == false)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f); // Tốc độ nhảy
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
