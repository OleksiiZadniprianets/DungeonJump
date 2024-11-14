using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class JumpPlatform : MonoBehaviour
{
    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        // Забезпечити, щоб колайдер був "trigger" для уникнення зупинки персонажа на платформі
        collider.isTrigger = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Можна додати додаткову логіку при зіткненні персонажа з платформою
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Гравець зіткнувся з платформою");
            PlayerJump playerJump = collision.gameObject.GetComponent<PlayerJump>();
            if (playerJump != null)
            {
                playerJump.Jump();            }
        }
    }
}
