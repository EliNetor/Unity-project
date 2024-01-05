using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public bool IsGamePaused()
    {
        return isPaused;
    }

    public GameCanvasShow GameCanvasShowWin;
    public GameCanvasShow GameCanvasShowLose;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        CheckIfPlayerWon("Collectables");
        CheckIfPlayerFell();
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Freezes the game
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
    }

    void CheckIfPlayerWon(string tagName)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagName);  // Als speler wint door alles te collecten.

        if (taggedObjects.Length == 0)
        {
            GameCanvasShowWin.WinSetup();
        }
    }

    void CheckIfPlayerFell()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Als speler valt van map

        if (player != null)
        {
            if (player.transform.position.y < -7f)
            {
                GameCanvasShowLose.LoseSetup();
            }
        }
    }
}
