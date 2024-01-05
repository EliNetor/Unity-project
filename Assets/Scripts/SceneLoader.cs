using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scene1;
    public string scene2;
    public string scene3;
    public string endCredits;

    public void LoadScene1()
    {
        Debug.Log("Loading level 1.");
        SceneManager.LoadScene(scene1);
    }

    public void LoadScene2()
    {
        Debug.Log("Loading level 2.");
        SceneManager.LoadScene(scene2);
    }

    public void LoadScene3()
    {
        Debug.Log("Loading level 3.");
        SceneManager.LoadScene(scene3);
    }
    public void LoadSceneCredits()
    {
        Debug.Log("Loading credits scene.");
        SceneManager.LoadScene(endCredits);
    }
}
