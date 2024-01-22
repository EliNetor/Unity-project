using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvasShow : MonoBehaviour
{
    [SerializeField] private string NextLVL;
    public void WinSetup()
    {
        gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(NextLVL);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("menu");
    }

    public void LoseSetup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
