using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    public void StartDemo()
    {
        SceneManager.LoadScene("DemoLevel");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("DemoLevel");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
