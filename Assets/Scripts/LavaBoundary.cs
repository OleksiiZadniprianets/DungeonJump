using UnityEngine;
using UnityEngine.SceneManagement; // для завантаження сцен

public class LavaBoundary : MonoBehaviour
{
    private TimerScore timerScore; // посилання на TimerScore

    private void Start()
    {
        // Знаходимо об'єкт TimerScore на сцені
        timerScore = Object.FindFirstObjectByType<TimerScore>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Викликаємо EndGame() перед переходом на сцену кінця гри
        if (timerScore != null)
        {
            timerScore.EndGame();
        }

        // Переходимо на сцену кінця гри
        SceneManager.LoadScene("GameOverScene");
    }
}
