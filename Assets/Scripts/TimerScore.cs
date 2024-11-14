using UnityEngine;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TextMeshProUGUI timerText; // переконайтесь, що це TextMeshProUGUI
    public float timeElapsed = 0f;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = "Time: " + Mathf.FloorToInt(timeElapsed).ToString();
        }
    }

    public void EndGame()
{
    isGameOver = true;

    // Перевірка на наявність HighScoreManager.Instance
    if (HighScoreManager.Instance != null)
    {
        HighScoreManager.Instance.SaveScore(Mathf.FloorToInt(timeElapsed));
    }
    else
    {
        Debug.LogWarning("HighScoreManager.Instance не знайдений на сцені.");
    }
}
}