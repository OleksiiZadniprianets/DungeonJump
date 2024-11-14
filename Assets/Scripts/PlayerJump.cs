using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f; // Швидкість горизонтального руху
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Camera mainCamera;
    private float cameraMinX, cameraMaxX;
    public float borderOffset = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        CalculateCameraBounds();
    }

    void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        // Отримуємо горизонтальне значення від -1 до 1
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(horizontalInput, 0);
    }

    void FixedUpdate()
    {
        // Рух вліво/вправо з заданою швидкістю
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);

        // Перевірка на вихід за межі камери
        RestrictMovementWithinCameraBounds();
    }

    private void CalculateCameraBounds()
    {
        // Отримуємо межі камери в світових координатах
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        
        cameraMinX = bottomLeft.x + borderOffset;
        cameraMaxX = topRight.x - borderOffset;
    }

    private void RestrictMovementWithinCameraBounds()
    {
        Vector3 position = transform.position;

        // Обмежуємо переміщення по осі X
        position.x = Mathf.Clamp(position.x, cameraMinX, cameraMaxX);

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Зупинка горизонтальної швидкості при зіткненні зі стіною
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // зупиняємо горизонтальний рух
        }
        else if (collision.gameObject.CompareTag("Ceiling"))
        {
            // Зупинка вертикальної швидкості при ударі об стелю
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }

    public void Jump()
    {
        // Стрибок завжди вгору
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // обнуляємо вертикальну швидкість
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void JumpWithMultiplier(float multiplier)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Обнуляємо вертикальну швидкість
        rb.AddForce(Vector2.up * jumpForce * multiplier, ForceMode2D.Impulse); // Стрибок з множником сили
    }
}
