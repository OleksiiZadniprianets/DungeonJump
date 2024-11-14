using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordButton : MonoBehaviour
{
    public void OnRecordClick()
    {
        SceneManager.LoadScene("Record"); // Переходить на RecordScene
    }
}
