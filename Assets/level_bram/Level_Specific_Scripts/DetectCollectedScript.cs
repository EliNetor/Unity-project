using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class DetectCollectedScript : MonoBehaviour
{
    public string sceneToLoad;
    public Volume oldVolume;
    public Volume newVolume;
    public GameObject task;
    public GameObject celebration;


    private void Update()
    {
        if (transform.childCount == 0)
        {
            oldVolume.enabled = false;
            newVolume.enabled = true;
            task.SetActive(false);
            celebration.SetActive(true);
            Invoke("LoadMenu", 10f);
        }
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
