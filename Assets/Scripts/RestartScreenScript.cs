using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreenScript : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
