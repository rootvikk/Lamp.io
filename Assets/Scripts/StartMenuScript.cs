using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnExit()
    { 
        Application.Quit();
    }
}
