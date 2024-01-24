using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string sceneName;


    void ButtonClicked(int buttonNo)
    {
        SceneManager.LoadScene(sceneName);
    }
}
