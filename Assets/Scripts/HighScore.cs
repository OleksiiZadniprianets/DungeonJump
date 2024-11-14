using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoresText;
    private const int MaxScores = 10;
    private List<int> highScores = new List<int>();

    public static HighScoreManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScores();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TryDisplayScores()
    {
        // Шукає TextMeshProUGUI тільки в RecordScene
        highScoresText = Object.FindAnyObjectByType<TextMeshProUGUI>();

        if (highScoresText != null)
        {
            DisplayScores();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI не знайдений у поточній сцені для відображення списку результатів.");
        }
    }

private void DisplayScores()
{
    highScoresText.text = "High Scores:\n";
    for (int i = 0; i < highScores.Count; i++)
    {
        highScoresText.text += $"{i + 1}. {highScores[i]}\n"; // Додаємо номер поряд з кожним результатом
    }
}


    public void SaveScore(int score)
    {
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a));

        if (highScores.Count > MaxScores)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

    public void LoadScores()
    {
        highScores.Clear();

        for (int i = 0; i < MaxScores; i++)
        {
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                highScores.Add(PlayerPrefs.GetInt("HighScore" + i));
            }
        }
    }
}
