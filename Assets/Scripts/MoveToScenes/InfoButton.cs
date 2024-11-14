using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InfoButton : MonoBehaviour
{
   public void OnInfoClick()
    {
       SceneManager.LoadScene("Info");
    }
}
