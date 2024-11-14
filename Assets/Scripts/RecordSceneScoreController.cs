using UnityEngine;

public class RecordSceneController : MonoBehaviour
{
    void Start()
    {
        HighScoreManager.Instance.TryDisplayScores(); // Викликає TryDisplayScores тільки в RecordScene
    }
}
