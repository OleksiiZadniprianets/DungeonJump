using UnityEngine;

public class MushroomJump : MonoBehaviour
{
    public float jumpMultiplier = 3f; // Потрійна сила стрибка

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Отримуємо доступ до компоненту PlayerJump і збільшуємо силу стрибка
            PlayerJump playerJump = collision.gameObject.GetComponent<PlayerJump>();
            if (playerJump != null)
            {
                playerJump.JumpWithMultiplier(jumpMultiplier);
            }
        }
    }
}
