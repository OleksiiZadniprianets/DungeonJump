using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameButton : MonoBehaviour
{
   public void OnButtonClick()
    {
       SceneManager.LoadScene("GameScene");
    }
}