using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvasShow : MonoBehaviour
{
    string test;
    public void WinSetup()
    {
        gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        //SceneManager.LoadScene("Sample Scene");
        test = "k";
    }

    public void MainMenuButton()
    {
        //SceneManager.LoadScene("Mainmenu");
        test = "k";
    }

    public void LoseSetup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("level_muhammed");
    }
}
