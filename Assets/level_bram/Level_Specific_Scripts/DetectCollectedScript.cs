using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class DetectCollectedScript : MonoBehaviour
{
    public MonoBehaviour script1; // Assign in Unity Editor
    public string method1; // Assign in Unity Editor
    public string SceneToLoad;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            script1.Invoke(method1, 0f); // Call the first method immediately
            Invoke("LoadMenu", 10f);
        }
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
