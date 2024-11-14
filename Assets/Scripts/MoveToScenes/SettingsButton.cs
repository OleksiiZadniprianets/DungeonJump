using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsButton : MonoBehaviour
{
   public void OnSettingsClick()
    {
       SceneManager.LoadScene("SettingsScene");
    }
}
