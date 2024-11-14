using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Статична змінна для глобального доступу
    public float speedMultiplier = 1.0f;   // Множник для збільшення швидкості платформ

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Зберігає об’єкт при переході між сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Збільшуємо множник швидкості кожну секунду
        InvokeRepeating("IncreaseSpeed", 1f, 1f);
    }

    private void IncreaseSpeed()
    {
        speedMultiplier += 0.01f; // Збільшуємо швидкість на 1% щосекунди
    }
}
